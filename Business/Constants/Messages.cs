using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UsersListed="Kullanıcılar listelendi";
        public static string MaintananceTime="Bakım zamanı";
        public static string UserAdded="Kullanıcı Eklendi";
        public static string UserDeleted="Kullanıcı Silindi";
        public static string UserListed="Kullanıcı Listelendi";
        public static string UsersListedByMail="Kullanıcılar Maillerine göre listelendi";
        public static string UserDetailsListed="Kullanıcı detayları listelendi";
        public static string UsersListedByName="Kullanıcılar isimlerine göre listelendi";
        public static string UserUpdated="Kullanıcı Güncellendi";
        public static string UserRegistered="Kullanıcı başarıyla kayıt oldu";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı parola";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserAlreadyExists="Kullanıcı zaten mavcut";
        public static string AccessTokenCreated="Giriş tokeni oluşturuldu";
        internal static string CarImagesAdded;
        internal static string CarImagesDeleted;
        internal static string CarImagesUpdated;
        internal static string CheckIfCarImagesCarLimit;
    }
}
