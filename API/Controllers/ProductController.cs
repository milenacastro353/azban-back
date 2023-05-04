using API.Response;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly RepoProduct business;

        public ProductController(DatabaseContext context)
        {
            business = new RepoProduct() { context = context };
        }

        [HttpGet("GetProductList")]
        public WebResponse GetProductList()
        {
            var products = business.GetProductList();

            return new WebResponse()
            {
                Code = 1,
                Message = "Exitoso",
                Response = products
            };
        }
    }
}
