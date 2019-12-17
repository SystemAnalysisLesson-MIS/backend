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
    public class KullaniciRegisterDtoValidator:AbstractValidator<KullaniciRegisterDto>
    {

        private Regex regex;
        public KullaniciRegisterDtoValidator()
        {
            RuleFor(register=>register.ad).NotEmpty()
                .MinimumLength(3).MaximumLength(60)
                .WithMessage(ValidationMessages.Bos_Girilemez+"veya"+ValidationMessages.KisaAd);

            RuleFor(register => register.soyad).NotEmpty()
                .MinimumLength(3).MaximumLength(60)
                .WithMessage(ValidationMessages.Bos_Girilemez+"veya"+ValidationMessages.KisaSoyad);

            RuleFor(register => register.kullaniciAdi).NotEmpty()
                .MinimumLength(3).MaximumLength(60)
                .WithMessage(ValidationMessages.Bos_Girilemez+"veya"+ValidationMessages.KisaKullaniciAd);


            RuleFor(register => register.email).NotEmpty().Custom((email, context) =>
            {
                if (!regex.CreateEmailRegex().VerifyToRegex(email))
                {
                    context.AddFailure(ValidationMessages.MailFormat);
                }
            });

            RuleFor(register => register.sifre).NotEmpty().WithMessage(ValidationMessages.Bos_Girilemez)
              .Custom((sifre, context) =>
              {
                  if (!regex.CreatePasswordRegex().VerifyToRegex(sifre))
                  {
                      context.AddFailure(ValidationMessages.sifre);
                  }
              });


            RuleFor(register => register.ceptelefonNumarasi).NotEmpty().WithMessage(ValidationMessages.Bos_Girilemez)
                .Custom((cepTelefonNumarasi, context) =>
                {
                    if (!regex.CreatePhoneNumberRegex().VerifyToRegex(cepTelefonNumarasi))
                    {
                        context.AddFailure(ValidationMessages.CepTelefonFormat);
                    }
                });


        }
    }
}
