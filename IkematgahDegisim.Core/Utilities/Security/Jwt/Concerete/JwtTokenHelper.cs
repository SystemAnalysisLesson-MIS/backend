using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.Utilities.Security.Encryption;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Abstract;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Security.Jwt.Concerete
{
    public class JwtTokenHelper : ITokenHelper
    {
        public IConfiguration configuration { get; set; }
        private TokenOptions TokenOptions { get; set; }
        private DateTime accessTokenExpirationTime { get; set; }

        private DateTime refreshTokenExpirationTime { get; set; }

        public JwtTokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            TokenOptions=configuration.GetSection("TokenOptions").Get<TokenOptions>();
            accessTokenExpirationTime = DateTime.Now.AddMinutes(TokenOptions.AccessTokenExpiration);
            //refreshTokenExpirationTime = DateTime.Now.AddMinutes(TokenOptions.RefreshTokenExpiration);
        }

      


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,Kullanici kullanici,SigningCredentials signingCredentials,List<OperasyonelTalep> operasyonelTalepler)
        {
            var jwt = new JwtSecurityToken
            (
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpirationTime,
                notBefore: DateTime.Now,
                claims: SetClaims(kullanici, operasyonelTalepler),
                signingCredentials: signingCredentials
            ) ;

            return jwt;
            
        }

        //private string CreateRefreshToken()
        //{
        //    var numberByte = new Byte[32];
        //    using (var randomGenerator = RandomNumberGenerator.Create())
        //    {
        //        randomGenerator.GetBytes(numberByte);

        //        return Convert.ToBase64String(numberByte);
        //    }
        
        //}

        //public void RevokeRefreshToken(Kullanici kullanici)
        //{
        //    //adjust to Null refresh token
        //    kullanici.refreshToken = null;
        //}


        private IEnumerable<Claim> SetClaims(Kullanici kullanici,List<OperasyonelTalep> operasyonelTalepler)
        {
            var claims = new List<Claim>();
            claims.AddName($"{kullanici.ad}+{kullanici.soyad}");
            claims.AddIdentifierName(kullanici.Id.ToString());
            claims.AddEmail(kullanici.email);
            claims.AddRoles(operasyonelTalepler.Select(o => o.name).ToArray());
                
            return claims;
        }


        public AccessToken CreateToken(Kullanici kullanici, List<OperasyonelTalep> operasyonelTalepler)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(TokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(TokenOptions, kullanici, signingCredentials, operasyonelTalepler);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                token = token,
                expireDate= accessTokenExpirationTime,
               // refreshToken = CreateRefreshToken()
            };
        }
    }
}
