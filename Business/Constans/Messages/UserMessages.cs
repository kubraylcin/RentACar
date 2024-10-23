﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans.Messages
{
    public static class UserMessages
    {
        public static string UserAdded = "Kullanıcı Başarıyla Eklendi";
        public static string UserDeleted = "Kullanıcı Başarıyla Silindi";
        public static string UserUpdated = "Kullanıcı Başarıyla Güncellendi";
        public static string UsersListed = "Kullanıcıler Başarıyla Listelendi";
        public static string UsersClaimsListed = "Kullanıcıler Rolleri Başarıyla Listelendi";
        public static string UserGet = "Kullanıcı Başarıyla Getirildi";
        public static string UserNotFound = "Böyle bir kullanıcı mevcut değil";
        public static string PasswordError = "Şifre Hatalı!";
        public static string SuccessfulLogin = "Sisteme Giriş Başarılı";
        public static string UserAlreadyExisits = "Bu Kullanıcı zaten mevcut!";
        public static string UserRegistered = "Kullanıcı Başarıyla Kayıt Oldu";
        public static string AccessTokenCreated = "AccessToken Başarıyla Oluşturuldu";
    }
}
