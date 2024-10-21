using Business.Abstracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        // Müşteri kaydı için endpoint
        [HttpPost("register/customer")]
        public ActionResult RegisterCustomer(CustomerForRegisterDto customerForRegisterDto)
        {
            var userExists = _authService.UserExists(customerForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.RegisterCustomer(customerForRegisterDto, customerForRegisterDto.Password);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }

            // E-posta doğrulama kodunu burada kaydedebiliriz
            return Ok(new { Message = registerResult.Message, Email = customerForRegisterDto.Email });
        }

        // Satıcı kaydı için endpoint
        [HttpPost("register/seller")]
        public ActionResult RegisterSeller(SellerForRegisterDto sellerForRegisterDto)
        {
            var userExists = _authService.UserExists(sellerForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.RegisterSeller(sellerForRegisterDto, sellerForRegisterDto.Password);
            if (!registerResult.Success)
            {
                return BadRequest(registerResult.Message);
            }

            // E-posta doğrulama kodunu burada kaydedebiliriz
            return Ok(new { Message = registerResult.Message, Email = sellerForRegisterDto.Email });
        }

        // E-posta doğrulama kodunu kontrol eden endpoint
        [HttpPost("verify-email")]
        public ActionResult VerifyEmail(string email, string confirmationCode)
        {
            var result = _authService.VerifyEmail(email, confirmationCode);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
    }
}
