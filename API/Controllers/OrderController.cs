using API.Response;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Dto;
using Repository.StoreProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly RepoOrder business;

        public OrderController(DatabaseContext context)
        {
            business = new RepoOrder() { context = context };
        }

        [HttpGet("GetInProccessOrders")]
        public WebResponse GetInProccessOrders()
        {
            var orders = business.GetInProccessOrders();

            return new WebResponse()
            {
                Code = 1,
                Message = "Exitoso",


                Response = orders
            };
        }

        [HttpPost("CreateOrder")]
        public WebResponse CreateOrder([FromBody] SpCreateOrderDto order)
        {
            var orderId = business.CreateOrder(order);

            return new WebResponse()
            {
                Code = orderId > 0 ? 1 : -1,
                Message = orderId > 0 ? "Exitoso" : "Fallido",
                Response = orderId
            };
        }
        
        [HttpGet("GetOrderByDocument/{orderId}/{documentType}/{documentNumber}")]
        public WebResponse GetOrderByDocumentState(int orderId, int documentType, string documentNumber)
        {
            var order = business.GetOrderByDocumentState(orderId, documentType, documentNumber);

            return new WebResponse()
            {
                Code = order != null ? 1 : -1,
                Message = order != null ? "Exitoso" : "Fallido",
                Response = order
            };
        }

        [HttpGet("GetProductsToDo")]
        public WebResponse GetProductsToDo()
        {
            var toDo = business.GetProductsToDo();

            return new WebResponse()
            {
                Code = 1,
                Message = "Exitoso",
                Response = toDo
            };
        }

        [HttpGet("SetProductionCloth/{orderDetailId}")]
        public WebResponse SetProductionCloth(int orderDetailId)
        {
            var success = business.SetProductionCloth(orderDetailId);

            return new WebResponse()
            {
                Code = success ? 1 : -1,
                Message = success ? "Exitoso" : "Fallido",
                Response = true
            };
        }

        [HttpGet("GetOrderById/{orderId}")]
        public WebResponse GetOrderById(int orderId)
        {
            var order = business.GetOrder(orderId);

            return new WebResponse()
            {
                Code = order != null ? 1 : -1,
                Message = order != null ? "Exitoso" : "Fallido",
                Response = order
            };
        }

        [HttpGet("SetBaseProductExist/{orderDetailId}/{exist}")]
        public WebResponse ChangeExistProductBase(int orderDetailId, bool exist)
        {
            var success = business.ChangeExistProductBase(orderDetailId, exist);

            return new WebResponse()
            {
                Code = success ? 1 : -1,
                Message = success ? "Exitoso" : "Fallido",
                Response = true
            };
        }

        [HttpGet("SetSttampState/{orderDetailId}/{stateId}")]
        public WebResponse ChangeSttampState(int orderDetailId, int stateId)
        {
            var success = business.ChangeSttampState(orderDetailId, stateId);

            return new WebResponse()
            {
                Code = success ? 1 : -1,
                Message = success ? "Exitoso" : "Fallido",
                Response = true
            };
        }
        
        [HttpGet("ChangeState/{orderId}/{newStateId}")]
        public WebResponse ChangeState(int orderId, int newStateId)
        {
            var success = business.ChangeState(orderId, newStateId);

            return new WebResponse()
            {
                Code = success ? 1 : -1,
                Message = success ? "Exitoso" : "Fallido",
                Response = true
            };
        }

        [HttpGet("PayOrder/{orderId}")]
        public WebResponse PayOrder(int orderId)
        {
            var success = business.PayOrder(orderId);

            return new WebResponse()
            {
                Code = success ? 1 : -1,
                Message = success ? "Exitoso" : "Fallido",
                Response = true
            };
        }

        [HttpGet("GetStates")]
        public WebResponse GetStates()
        {
            var states = business.GetStates();

            return new WebResponse()
            {
                Code = 1,
                Message = "Exitoso",
                Response = states
            };
        }

        [HttpGet("ChangeAddress/{orderId}/{addressId}")]
        public WebResponse ChangeAddress(int orderId, int addressId)
        {
            var result = business.ChangeAddress(orderId, addressId);

            return new WebResponse()
            {
                Code = result ? 1 : -1,
                Message = "Exitoso",
                Response = result
            };
        }
        
    }
}
