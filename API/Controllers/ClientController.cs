using API.Response;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly RepoCliente business;

        public ClientController(DatabaseContext context)
        {
            business = new RepoCliente() { context = context };
        }

        [HttpGet("GetClient/{documentType}/{documentNumber}")]
        public WebResponse GetClient(int documentType, string documentNumber)
        {
            var client = business.GetClient(documentType, documentNumber);

            return new WebResponse()
            {
                Code = client.Id > 0 ? 1 : -1,
                Message = client.Id > 0 ? "Exitoso" : "Fallido",
                Response = client
            };
        }

        [HttpPost("CreateOrUpdate")]
        public WebResponse CreateOrUpdate([FromBody] ClientDto client)
        {
            var idClient = business.CreateOrUpdate(client);

            return new WebResponse()
            {
                Code = idClient > 0 ? 1 : -1,
                Message = idClient > 0 ? "Exitoso" : "Fallido",
                Response = idClient
            };
        }

        [HttpPost("AddAddress/{clientId}")]
        public WebResponse AddAddress(int clientId, [FromBody] AddressDto address)
        {
            var idAddress = business.AddAddress(clientId, address);

            return new WebResponse()
            {
                Code = idAddress > 0 ? 1 : -1,
                Message = idAddress > 0 ? "Exitoso" : "Fallido",
                Response = idAddress
            };
        }

        [HttpDelete("DeleteAddress/{addressId}")]
        public WebResponse DeleteAddress(int addressId)
        {
            var result = business.DeleteAddress(addressId);

            return new WebResponse()
            {
                Code = result ? 1 : -1,
                Message = result ? "Exitoso" : "Fallido",
                Response = result
            };
        }
    }
}
