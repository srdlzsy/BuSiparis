using Business.Abstracts;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
            private readonly ISellerService  _sellerService;

            public SellersController(ISellerService sellerService)
            {
                _sellerService = sellerService;
            }

            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _sellerService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                var result = _sellerService.GetById(id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

            [HttpPost("add")]
            public IActionResult Add(Seller seller)
            {
                var result = _sellerService.Add(seller);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }
            [HttpPost("update")]
            public IActionResult Update(Seller seller)
            {
                var result = _sellerService.Update(seller);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }

            [HttpDelete("deletebyid")]
            public IActionResult Delete(int id)
            {
                var customerToDelete = _sellerService.GetById(id);
                if (!customerToDelete.Success)
                {
                    return BadRequest(customerToDelete.Message);
                }

                var result = _sellerService.Delete(customerToDelete.Data);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
        }
   
}
