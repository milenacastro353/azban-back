using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Dto;
using System.Data;
using Microsoft.Data.SqlClient;
using Repository.DataBaseDto;
using EntityFrameworkExtras.EFCore;
using Repository.StoreProcedure;

namespace Repository
{
    public class RepoCliente
    {
        public DatabaseContext context;

        public ClientDto GetClient(int documentType, string documentNumber)
        {
            var clientResult = new ClientDto();

            var client = context.Clients.FromSqlRaw($"ObtenerCliente {documentType}, {documentNumber}").AsNoTracking().ToList();


            if (client.Count() > 0)
            {
                clientResult.Id = client[0].Id;
                clientResult.Name = client[0].Name;
                clientResult.Phone = client[0].Phone;
                clientResult.Email = client[0].Email;
                clientResult.IdContactType = client[0].ContactId;
                clientResult.ContactValue = client[0].ContactValue;

                if (client[0].AddressId != 0)
                {
                    clientResult.Adresses = client.Select(c => new AddressDto() {
                        Id = c.AddressId,
                        Address = c.Address,
                        Addresse = c.Addresse,
                        AddressePhone = c.AddressePhone,
                        DepartmentId = c.DepartmentId,
                        DepartmentName = c.DepartmentName,
                        City = c.City,
                    }).ToList();
                }
            }

            return clientResult;
        }

        public int CreateOrUpdate(ClientDto client)
        {
            var parameters = new object[]
            {
                new SqlParameter("@nombre", client.Name),
                new SqlParameter("@idTipoDocumento", client.IdDocumentType),
                new SqlParameter("@numeroDocumento", client.Document),
                new SqlParameter("@celular", client.Phone),
                new SqlParameter("@idTipoContacto", client.IdContactType),
                new SqlParameter("@datoTipoContacto", client.ContactValue),
                new SqlParameter("@email", client.Email),
            };

            var clientResult = context.Clients.FromSqlRaw("CrearActualizarCliente @nombre, @idTipoDocumento, @numeroDocumento, @celular, @idTipoContacto, @datoTipoContacto, @email", parameters).ToList().FirstOrDefault();
            return clientResult.Id;
        }

        public bool DeleteAddress(int addressId)
        {
            var deleteAddressData = new SpDeleteAddressDto() { Id = addressId };

            context.Database.ExecuteStoredProcedure(deleteAddressData);

            return true;
        }

        public int AddAddress(int clientId, AddressDto address)
        {
            var parameters = new object[]
            {
                new SqlParameter("@idCliente", clientId),
                new SqlParameter("@destinatario", address.Addresse),
                new SqlParameter("@celularDestinatario", address.AddressePhone),
                new SqlParameter("@direccion", address.Address),
                new SqlParameter("@idDepartamento", address.DepartmentId),
                new SqlParameter("@ciudadMunicipio", address.City)
            };

            var addressResult = context.Addresses.FromSqlRaw("CrearDireccion @idCliente, @destinatario, @celularDestinatario, @direccion, @idDepartamento, @ciudadMunicipio", parameters).ToList().FirstOrDefault();

            return addressResult.Id;
        }

        public static void CrateOrUpdateClient()
        {

        }

        public static void AddAddress()
        {

        }


        public static void RemoveAddress()
        {

        }
    }
}
