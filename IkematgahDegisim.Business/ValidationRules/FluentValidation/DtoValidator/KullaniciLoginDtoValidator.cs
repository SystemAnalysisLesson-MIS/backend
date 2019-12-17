using FluentValidation;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Entity.Concerete.Dtos.Kullanici;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IkematgahDegisim.Business.ValidationRules.FluentValidation.DtoValidator
{
    public class KullaniciLoginDtoValidator:AbstractValidator<KullaniciLoginDto>
    {
        private Regex regex;

        public KullaniciLoginDtoValidator()
        {
            RuleFor(login => login.email).NotEmpty().WithMessage(ValidationMessages.Bos_Girilemez)
                .Custom((email, context) =>
                {
                    if (!regex.CreateEmailRegex().VerifyToRegex(email))
                    {
                        context.AddFailure(ValidationMessages.MailFormat);
                    }
                });

            RuleFor(login => login.sifre).NotEmpty().WithMessage(ValidationMessages.Bos_Girilemez)
               .Custom((sifre, context) =>
               {
                   if (!regex.CreatePasswordRegex().VerifyToRegex(sifre))
                   {
                       context.AddFailure(ValidationMessages.sifre);
                   }
               });

        }
    }
}
