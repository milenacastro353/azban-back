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
    public class TransversalController : ControllerBase
    {
        private readonly RepoOrder business;

        public TransversalController(DatabaseContext context)
        {
            business = new RepoOrder() { context = context };
        }

        [HttpGet("GetLists")]
        public WebResponse Get()
        {

            var lists = business.GetLists();

            return new WebResponse()
            {
                Code = 1,
                Message = "Exitoso",
                Response = lists
            };
        }
          
    }
}
