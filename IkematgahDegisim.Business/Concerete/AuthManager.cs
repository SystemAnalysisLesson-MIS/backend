using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Business.ValidationRules.FluentValidation.DtoValidator;
using IkematgahDegisim.Core.Aspects.Autofac.Validation;
using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.Core.Utilities.Security.Hashing;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Abstract;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Entities;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.Entity.Concerete.Dtos.Kullanici;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Concerete
{
    public class AuthManager : IAuthManager
    {
        private IKullaniciService kullaniciService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IKullaniciService kullaniciService,ITokenHelper tokenHelper)
        {
            this.kullaniciService = kullaniciService;
            this._tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici)
        {
            try
            {
                var operasyonelTalepler = kullaniciService.GetClaims(kullanici);
                AccessToken accessToken = _tokenHelper.CreateToken(kullanici, operasyonelTalepler.Data);
               // kullanici.refreshToken = accessToken.refreshToken;

                return new SuccessDataResult<AccessToken>(accessToken,UserOperationMessages.ErişimToken);
            }

            catch (Exception e)
            {
                return new FailDataResult<AccessToken>(UserOperationMessages.ErişimToken_Basarisiz);
            }
        }

        //public IDataResult<AccessToken> CreateAccessTokenwithRefreshToken(string refreshToken)
        //{
        //    throw new NotImplementedException();
        //}

        public IResult ExistByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IResult ExistsByMail(string mail)
        {
            if (kullaniciService.GetByEmail(mail)!=null)
            {
                return new FailResult(UserOperationMessages.Kullanici_Var);
            }
            return new SuccessResult();
        }


        [ValidationAspect(typeof(KullaniciLoginDtoValidator))]
        public IDataResult<Kullanici> Login(KullaniciLoginDto loginDto)
        {
            var userToCheck = kullaniciService.GetByEmail(loginDto.email);
            if (userToCheck == null)
            {
                return new FailDataResult<Kullanici>(UserOperationMessages.KullaniciAdi_Bulunamadi);
            }

            if (!HashingHelper.VerifyPassword(loginDto.sifre, userToCheck.Data.sifreHash, userToCheck.Data.sifreSalt))
            {
                return new FailDataResult<Kullanici>(UserOperationMessages.Basarisiz_Oturum_Acim);
            }

            return new SuccessDataResult<Kullanici>(userToCheck.Data,UserOperationMessages.Basarili_Oturum_Acim);
        }

        [ValidationAspect(typeof(KullaniciRegisterDtoValidator))]
        public IDataResult<Kullanici> Register(KullaniciRegisterDto registerDto,string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.HashingPassword(password, out passwordHash, out passwordSalt);
            var user = new Kullanici
            {
                email = registerDto.email,
                ad = registerDto.ad,
                soyad = registerDto.soyad,
                sifreHash=passwordHash,
                sifreSalt=passwordSalt,
                durum = true
            };
            kullaniciService.AddUser(user);
            return new SuccessDataResult<Kullanici>(UserOperationMessages.Kullanici_Basarili_bir_sekilde_olusturuldu);
        }

        //public Task<IDataResult<AccessToken>> RevokeRefreshToken(string refreshToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
