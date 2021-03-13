using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static  class Messages
    {
        public static string Added = " Eklendi";

        public static string NameInvalid = "Geçersiz isim";

        public static string Maintenancetime = "Sistem bakımda";

        public static string Listed = " Listelendi";

        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string RentInvalıd = "Araba zaten kiralandı";
        public static string CarOfImageLimitExceeded="Resim Limiti aşıldı.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt olundu.";
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Parola hatalı.";
        public static string SuccessfulLogin="Giriş başarılı.";
        public static string UserAlreadyExists="Kullanıcı mevcut";
        public static string AccessTokenCreated="Token oluşturuldu.";
    }
}
