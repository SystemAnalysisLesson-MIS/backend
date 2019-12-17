using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Entities;
using IkematgahDegisim.Entity.Concerete.Dtos.Kullanici;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
   public interface IAuthManager
    {
        IDataResult<Kullanici> Register(KullaniciRegisterDto registerDto,string password);

        IDataResult<Kullanici> Login(KullaniciLoginDto loginDto);

        IResult ExistsByMail(string mail);

        IResult ExistByPhoneNumber(string phoneNumber);

        IDataResult<AccessToken> CreateAccessToken(Kullanici kullanici);

        //IDataResult<AccessToken> CreateAccessTokenwithRefreshToken(string refreshToken);

       // IDataResult<AccessToken> RevokeRefreshToken(string refreshToken);
    }
}
