using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem Bakımda.";
        //Process
        public static string? AuthorizationDenied = "Yetkin Yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "kullanıcı hatası";
        public static string PasswordError = "Şifre hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut ";
        public static string AccessTokenCreated = "Giriş yapıldı";

        //User Messages
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string CarsListed = "Araçlar Listelendi";

        public static string InvalidConfirmationCode { get; internal set; }
        public static string EmailVerified { get; internal set; }
    }
}
