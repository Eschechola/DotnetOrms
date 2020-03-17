using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using DotnetORMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetORMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NHibernateController : ControllerBase, IController
    {
        private readonly IService Service;

        public NHibernateController()
        {
            Service = new NHibernateService();
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert([FromBody] User user)
        {
            try
            {
                Service.Insert(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("insert")]
        public IActionResult Update([FromBody] User user)
        {
            try
            {
                Service.Update(user);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Service.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(Service.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(Service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}