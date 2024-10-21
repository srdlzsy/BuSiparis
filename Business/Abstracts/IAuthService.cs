using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Dtos;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        //Müşteri kaydı 
        IDataResult<User> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto, string password);

        //Satıcı kaydı 
        IDataResult<User> RegisterSeller(SellerForRegisterDto sellerForRegisterDto, string password);

        //Login 
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        //Kullanıcı var mı kontrolü
        IResult UserExists(string email);

        //Access token oluşturma
        IDataResult<AccessToken> CreateAccessToken(User user);
        // E-posta doğrulama metodu
        IResult VerifyEmail(string email, string confirmationCode); // E-posta doğrulama metodu
    }

}
