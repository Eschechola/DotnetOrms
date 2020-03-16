using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetORMS.Interfaces;
using DotnetORMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetORMS.Controllers
{
    [ApiController]
    public class OrmController : ControllerBase
    {
        private IBaseService Service;

        public OrmController()
        {

        }

        [Route("/api/[controller]/entity")]
        [HttpGet]
        public IActionResult Entity()
        {
            try
            {
                Service = new EntityService();
                return Ok(Service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}