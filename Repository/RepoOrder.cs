using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Dto;
using Microsoft.Data.SqlClient;
using EntityFrameworkExtras.EFCore;
using Repository.DataBaseDto;
using DataAccess.Entity;
using Repository.StoreProcedure;
using System.IO;
using BlobStorageAccess;

namespace Repository
{
    public class RepoOrder
    {
        public DatabaseContext context;

        public ListsDto GetLists()
        {
            var lists = new ListsDto();

            lists.Departments = context.Deparments.FromSqlRaw("ObtenerDepartamentos").ToList();
            lists.DocumentTypes = context.DocumentTypes.FromSqlRaw("ObtenerTiposDocumentos").ToList();
            lists.PaymentMethods = context.PaymentMethods.FromSqlRaw("ObtenerMediosPago").ToList();
            lists.ContactTypes = context.ContactTypes.FromSqlRaw("ObtenerTiposContacto").ToList();

            return lists;
        }

        public List<OrderDto> GetInProccessOrders()
        {
            var ordersLists = context.Database.ExecuteStoredProcedure<RspOrderDto>(new SpObtenerPedidosProduccion()).ToList();
            
            var orders = ordersLists.GroupBy(o => o.Id).Select(o => new OrderDto()
            {
                Id = o.First().Id,
                ClientId = o.First().ClientId,
                Client = o.First().Client,
                Contact = o.First().Contact,
                StateId = o.First().StateId,
                State = o.First().State,
                Email = o.First().Email,
                Phone = o.First().Phone,
                DepartmentId = o.First().DepartmentId,
                Department = o.First().Department,
                City = o.First().City,
                AddressId = o.First().AddressId,
                Address = o.First().Address,
                PaymentMethodId = o.First().PaymentMethodId,
                PaymentMethod = o.First().PaymentMethod,
                Deposited = o.First().Deposited,
                Deposit = o.First().Deposit,
                Payed = o.First().Payed,
                DeliveryDate = o.First().DeliveryDate,
                CreationDate = o.First().CreationDate,
                NumImages = o.First().NumImages
            }).ToList();

            for(var i = 0; i < orders.Count(); i++)
            {
                orders[i].Products = ordersLists.Where(o => o.Id == orders[i].Id).Select(p => new ProductDto()
                {
                    Id = p.ProductDetailId,
                    ProductId = p.ProductId,
                    Product = p.Product,
                    Initials = p.Initials,
                    SizeId = p.SizeId,
                    Size = p.Size,
                    ColorId = p.ColorId,
                    Color = p.Color,
                    Quantity = p.Quantity,
                    Gender = p.Gender,
                    MainPrint = p.MainPrint,
                    SecundaryPrint = p.SecundaryPrint,
                    Anotation = p.Anotation,
                    StateId = p.StateId,
                    State = p.State,
                    ProccessStampId = p.ProccessStampId,
                    ReadyProductBase = p.ReadyProductBase,
                    ToDo = p.ToDo
                }).ToList();
            }
            return orders.ToList();
        }

        public List<RspToDoProductDto> GetProductsToDo()
        {
            var toConsult = new SpGetToDoProducts();
            var productsResult = context.Database.ExecuteStoredProcedure<RspToDoProductDto>(toConsult).ToList();

            return productsResult;
        }

        public OrderHistoryDto GetOrderByDocumentState(int orderId, int documentType, string documentNumber)
        {
            var orderHistorySates = new OrderHistoryDto();
            var datoRequest = new SpGetOrderState() { OrderId = orderId, DocumentTypeId = documentType, DocumentNumber = documentNumber };

            var orderResult = context.Database.ExecuteStoredProcedure<RspOrderProccessStateDto>(datoRequest).ToArray();
            var initialIteration = true;

            foreach(var state in orderResult)
            {
                if (initialIteration)
                {
                    initialIteration = false;
                    orderHistorySates.OrderId = state.OrderId;
                    orderHistorySates.Payed = state.Payed;
                    orderHistorySates.DeliveryDate[0] = state.DeliveryDate;
                    orderHistorySates.DeliveryDate[1] = state.DeliveryDate.AddDays(1);
                    orderHistorySates.CurrentOrderState = state.CurrentOrderState;
                    orderHistorySates.CreatedDate = state.CreatedDate;
                    orderHistorySates.ClientName = state.ClientName;
                    orderHistorySates.ClientDocument = state.ClientDocument;
                }

                orderHistorySates.States.Add(new OrderHistoryStateDto()
                {
                    StateId = state.StateId,
                    State = state.State,
                    StateDate = state.StateDate
                });
            }

            return orderHistorySates;
        }

        public bool ChangeAddress(int orderId, int addressId)
        {
            var orderDetailSttampState = new SpChangeOrderAddress() { OrderId = orderId, SAddressId = addressId };

            context.Database.ExecuteStoredProcedure(orderDetailSttampState);

            return true;
        }

        public bool ChangeSttampState(int orderDetailId, int stateId)
        {
            var orderDetailSttampState = new SpChangeSttampState() { OrderDetailId = orderDetailId, SttampState = stateId };

            context.Database.ExecuteStoredProcedure(orderDetailSttampState);

            return true;
        }

        public bool SetProductionCloth(int orderDetailId)
        {
            var orderDetailProductionClothes = new SpSetProductionClothes() { OrderDetailId = orderDetailId };

            context.Database.ExecuteStoredProcedure(orderDetailProductionClothes);

            return true;
        }

        public bool ChangeExistProductBase(int orderDetailId, bool exist)
        {
            var orderDetailExistProductBase = new SpSetProductBaseExist() { OrderDetailId = orderDetailId, ProductBaseExist = exist };

            context.Database.ExecuteStoredProcedure(orderDetailExistProductBase);

            return true;
        }
        

        public List<RspOrderStateDto> GetStates()
        {
            var states = context.Database.ExecuteStoredProcedure<RspOrderStateDto>(new SpGetStates()).ToList();

            return states;
        }

        public bool PayOrder(int orderId)
        {
            var orderData = new SpPayOrder() { OrderId = orderId};

            context.Database.ExecuteStoredProcedure(orderData);

            return true;
        }

        public int CreateOrder(SpCreateOrderDto order)
        {
            order.numImages = order.Images.Count();
            var orderId = context.Database.ExecuteStoredProcedure<RspNewIdDto>(order).ToArray();
            var imageCount = 1;

            if (orderId.Length > 0)
            {
                order.Images.ForEach(image =>
                {
                    try
                    {
                        var iBytes = Convert.FromBase64String(image.Base64);
                        var ms = new MemoryStream(iBytes);
                        BlobStorageProvider.UploadImg($"{orderId[0].Id}-{imageCount}", "jpg", $"{orderId[0].Id}", ms);
                    }
                    catch (Exception ex) { }

                    imageCount++;
                });
            }

            return orderId[0].Id;
        }

        public bool  ChangeState(int orderId, int stateId)
        {
            var orderData = new SpChangeOrderState() { OrderId = orderId, StateId = stateId };

            context.Database.ExecuteStoredProcedure(orderData);

            return true;
        }

        public OrderDto GetOrder(int orderId)
        {
            var orderHistorySates = new OrderHistoryDto();
            var datoRequest = new SpGetOrderById() { OrderId = orderId };

            var orderResult = context.Database.ExecuteStoredProcedure<RspOrderDto>(datoRequest).ToList();

            var orders = orderResult.GroupBy(o => o.Id).Select(o => new OrderDto()
            {
                Id = o.First().Id,
                ClientId = o.First().ClientId,
                Client = o.First().Client,
                Contact = o.First().Contact,
                StateId = o.First().StateId,
                State = o.First().State,
                Email = o.First().Email,
                Phone = o.First().Phone,
                DepartmentId = o.First().DepartmentId,
                Department = o.First().Department,
                City = o.First().City,
                AddressId = o.First().AddressId,
                Address = o.First().Address,
                PaymentMethodId = o.First().PaymentMethodId,
                PaymentMethod = o.First().PaymentMethod,
                Deposited = o.First().Deposited,
                Deposit = o.First().Deposit,
                Payed = o.First().Payed,
                DeliveryDate = o.First().DeliveryDate,
                CreationDate = o.First().CreationDate,
                NumImages = o.First().NumImages
            }).ToList();

            for (var i = 0; i < orders.Count(); i++)
            {
                orders[i].Products = orderResult.Where(o => o.Id == orders[i].Id).Select(p => new ProductDto()
                {
                    Id = p.ProductDetailId,
                    ProductId = p.ProductId,
                    Product = p.Product,
                    Initials = p.Initials,
                    SizeId = p.SizeId,
                    Size = p.Size,
                    ColorId = p.ColorId,
                    Color = p.Color,
                    Quantity = p.Quantity,
                    Gender = p.Gender,
                    MainPrint = p.MainPrint,
                    SecundaryPrint = p.SecundaryPrint,
                    Anotation = p.Anotation,
                    StateId = p.StateId,
                    State = p.State,
                    ProccessStampId = p.ProccessStampId,
                    ReadyProductBase = p.ReadyProductBase,
                    ToDo = p.ToDo
                }).ToList();
            }

            return orders.FirstOrDefault();
        }
    }
}
