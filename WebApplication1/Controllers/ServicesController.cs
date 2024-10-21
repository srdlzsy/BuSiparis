using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

  
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _serviceService.GetAll();
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result.Message); 
        }

 
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _serviceService.GetById(id);
            if (result.Success)
            {
                return Ok(result); 
            }
            return NotFound(result.Message); 
        }


        [HttpPost("add")]
        public IActionResult Add(Service service)
        {
            var result = _serviceService.Add(service);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result.Message); 
        }

 
        [HttpPut("updatebyid")]
        public IActionResult Update(int id, Service service)
        {
            if (service.ServiceId != id)
            {
                return BadRequest("Service ID mismatch");
            }

            var result = _serviceService.Update(service);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result.Message); 
        }


        [HttpDelete("deletebyid")]
        public IActionResult Delete(int id)
        {
            var serviceToDelete = _serviceService.GetById(id);
            if (!serviceToDelete.Success)
            {
                return NotFound(serviceToDelete.Message); 
            }

            var result = _serviceService.Delete(serviceToDelete.Data);
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result.Message); 
        }
    }
}
