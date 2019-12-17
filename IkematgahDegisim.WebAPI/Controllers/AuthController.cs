
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete.Dtos.Kullanici;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthManager _authService;
        public AuthController(IAuthManager authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(KullaniciLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return this.BadRequestWithMessage(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return this.OkWithData(result.Data,result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(KullaniciRegisterDto userForRegisterDto)
        {
            var userExists = _authService.ExistsByMail(userForRegisterDto.email);
            if (!userExists.Success)
            {
                return this.BadRequestWithMessage(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.sifre);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return this.OkWithData(result.Data,result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }
    }
}
