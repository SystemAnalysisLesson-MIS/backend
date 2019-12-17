using FluentValidation;
using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace IkematgahDegisim.Business.ValidationRules.FluentValidation
{
    public class KullaniciValidator:AbstractValidator<Kullanici>
    {
        private Regex regex;
        public KullaniciValidator()
        {
            RuleFor(k=>k.ad).NotEmpty().MinimumLength(3).MaximumLength(60).WithMessage(ValidationMessages.Bos_Girilemez+"veya"+ValidationMessages.KisaAd);
            RuleFor(k => k.email).NotEmpty().Custom((email, context) =>
            {
                if (!regex.CreateEmailRegex().VerifyToRegex(email))
                {
                    context.AddFailure(ValidationMessages.MailFormat);
                }
            });

            RuleFor(k => k.ceptelefonNumarasi).NotEmpty().Custom((cepTelefonNumarasi, context) =>
            {
                if (!regex.CreatePhoneNumberRegex().VerifyToRegex(cepTelefonNumarasi))
                {
                    context.AddFailure(ValidationMessages.CepTelefonFormat);
                }
            });

           

            
        }
    }
}
