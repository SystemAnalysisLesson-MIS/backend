using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Constants
{
    public static class ValidationMessages
    {
        public static string Bos_Girilemez = "Bilgileriniz boş geçirilemez";
        public static string CepTelefonFormat = "Cep telefonuna formatına uygun olmayan şekilde Cep Telefon numarası girdiniz";
        public static string TCKimlikFormat = "TC Kimlik formatına uygun olmayan şekilde TCKimlik girdiniz";
        public static string MailFormat = "EMail adresi formatına uygun olmayan şekilde Email girdiniz";
        public static string EvAdresFormat = "Ev adres formatına uygun olmayan şekilde Ev adresi girdiniz";
        public static string KisaAd = "Ad için çok kısa bir ad girmeye kalktınız";
        public static string KisaSoyad = "Soyad için çok kısa bir soyad girmeye kalktınız";
        public static string sifre = "Şifreniz doğru formatta girmemiş ya da olması gerektiğinde kısa girmiş olabilirsiniz";
        public static string KisaKullaniciAd = "Kullanici adi için kısa bir kullanıcı adı girdiniz";
        public static string CepTelefonBaslangic = "Cep telefon numaranız ilk iki hanede muhakak 05 olmalı";
        public static string KısaGiriş = "Girdiğiniz veri olması gerektiğinde kısa";

        public static string DogumTarihiFormat = "Doğum tarihi doğru formatta değil";
    }
}
