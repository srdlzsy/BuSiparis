using Business.Abstracts;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos;
using MimeKit;
using MailKit.Net.Smtp; // Doğru namespace
using System;
using System.Collections.Generic; // Dictionary için gerekli
using System.Security.Cryptography;
using System.Text;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ISellerService _sellerService;
        private readonly ICustomerService _customerService;
        private readonly ITokenHelper _tokenHelper;
        private readonly Dictionary<string, string> _confirmationCodes; // Onay kodları için dictionary

        public AuthManager(IUserService userService, ISellerService sellerService, ICustomerService customerService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _sellerService = sellerService;
            _customerService = customerService;
            _tokenHelper = tokenHelper;
            _confirmationCodes = new Dictionary<string, string>(); // Dictionary'i başlat
        }

        public IDataResult<User> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            var userExistsResult = UserExists(customerForRegisterDto.Email);
            if (!userExistsResult.Success)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = customerForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsEmailVerified = false
            };

            _userService.Add(user);

            var confirmationCode = GenerateConfirmationCode();
            SendEmailConfirmationCode(customerForRegisterDto.Email, confirmationCode);
            _confirmationCodes[customerForRegisterDto.Email] = confirmationCode;

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> RegisterSeller(SellerForRegisterDto sellerForRegisterDto, string password)
        {
            var userExistsResult = UserExists(sellerForRegisterDto.Email);
            if (!userExistsResult.Success)
            {
                return new ErrorDataResult<User>(Messages.UserAlreadyExists);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = sellerForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsEmailVerified = false
            };

            _userService.Add(user);

            var confirmationCode = GenerateConfirmationCode();
            SendEmailConfirmationCode(sellerForRegisterDto.Email, confirmationCode);
            _confirmationCodes[sellerForRegisterDto.Email] = confirmationCode;

            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult VerifyEmail(string email, string confirmationCode)
        {
            if (_confirmationCodes.TryGetValue(email, out var storedCode) && storedCode == confirmationCode)
            {
                var user = _userService.GetByMail(email);
                if (user.Data != null)
                {
                    user.Data.IsEmailVerified = true;
                    _userService.Update(user.Data);
                    _confirmationCodes.Remove(email);
                    return new SuccessResult(Messages.EmailVerified);
                }
                return new ErrorResult(Messages.UserNotFound);
            }
            return new ErrorResult(Messages.InvalidConfirmationCode);
        }

        private void SendEmailConfirmationCode(string email, string confirmationCode)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Your Name", "your-email@example.com")); // E-posta adresinizi buraya yazın
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Doğrulama Kodu";
            message.Body = new TextPart("html")
            {
                Text = $"Doğrulama kodunuz: <strong>{confirmationCode}</strong>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("your-email@example.com", "your-app-password"); // Uygulama şifresi
                    client.Send(message);
                    Console.WriteLine($"E-posta gönderildi: {email}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        private string GenerateConfirmationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

      
    }
}
