using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainServiceCategoriesController : ControllerBase
    {
        private readonly IMainServiceCategoryService _mainServiceCategoryService;

        public MainServiceCategoriesController(IMainServiceCategoryService mainServiceCategoryService)
        {
            _mainServiceCategoryService = mainServiceCategoryService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _mainServiceCategoryService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data); 
            }
            return BadRequest(result.Message);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _mainServiceCategoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data); 
            }
            return NotFound(result.Message);
        }


        [HttpPost]
        public IActionResult Add(MainServiceCategory mainServiceCategory)
        {
            var result = _mainServiceCategoryService.Add(mainServiceCategory);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message); 
        }

       
        [HttpPut("{id}")]
        public IActionResult Update(int id, MainServiceCategory mainServiceCategory)
        {
            if (mainServiceCategory.MainServiceCategoryId != id)
            {
                return BadRequest();
            }

            var result = _mainServiceCategoryService.Update(mainServiceCategory);
            if (result.Success)
            {
                return Ok(result.Message); 
            }
            return BadRequest(result.Message); 
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var mainServiceCategoryToDelete = _mainServiceCategoryService.GetById(id);
            if (!mainServiceCategoryToDelete.Success)
            {
                return NotFound(mainServiceCategoryToDelete.Message); 
            }

            var result = _mainServiceCategoryService.Delete(mainServiceCategoryToDelete.Data);
            if (result.Success)
            {
                return Ok(result.Message); 
            }
            return BadRequest(result.Message); 
        }
    }
}
