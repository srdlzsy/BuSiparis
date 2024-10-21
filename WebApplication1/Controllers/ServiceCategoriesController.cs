using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
        IServiceCategoryService _serviceCategoryService;

        public ServiceCategoriesController(IServiceCategoryService serviceCategoryService)
        {
            _serviceCategoryService = serviceCategoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _serviceCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _serviceCategoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(ServiceCategory serviceCategory)
        {
            var result = _serviceCategoryService.Add(serviceCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPut("updatebyid")]
        public IActionResult Update(int id, ServiceCategory serviceCategory)
        {
            if (serviceCategory.ServiceCategoryId != id)
            {
                return BadRequest();
            }

            var result = _serviceCategoryService.Update(serviceCategory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpDelete("deletebyid")]
        public IActionResult Delete(int id)
        {
            var serviceToDelete = _serviceCategoryService.GetById(id);
            if (!serviceToDelete.Success)
            {
                return NotFound(serviceToDelete.Message);
            }

            var result = _serviceCategoryService.Delete(serviceToDelete.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
