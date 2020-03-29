using System;
using DotnetORMS.Interfaces;
using DotnetORMS.Models;
using DotnetORMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetORMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase, IController
    {
        private readonly IService Service;

        public DapperController(DapperService service)
        {
            Service = service;
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
        [Route("update")]
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