using FluentValidation;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Text.RegularExpressions;

namespace IkematgahDegisim.Business.ValidationRules.FluentValidation
{
    public class VatandasValidator:AbstractValidator<Vatandas>
    {
        private Regex regex;
        public VatandasValidator()
        {
            RuleFor(v => v.tcKimlik).NotEmpty().Must(tcKimlik => tcKimlik.ToString().Length == 11).WithMessage(ValidationMessages.KısaGiriş+"ya da "+ValidationMessages.Bos_Girilemez)
                .Custom((tcKimlik, context) =>
                {
                    if (!regex.CreateTcKimlikRegex().VerifyToRegex(tcKimlik.ToString()))
                    {
                        context.AddFailure(ValidationMessages.TCKimlikFormat);
                    }
                });


            RuleFor(v => v.dogumTarih).NotEmpty().WithMessage(ValidationMessages.Bos_Girilemez)
               .Custom((dogumTarihi, context) =>
               {
                   if (!regex.CreateBirthDateRegex().VerifyToRegex(dogumTarihi.ToString()))
                   {
                       context.AddFailure(ValidationMessages.DogumTarihiFormat);
                   }
               });


            RuleFor(v => v.ad).NotEmpty().MinimumLength(3).MaximumLength(60).WithMessage(ValidationMessages.Bos_Girilemez+" veya "+ValidationMessages.KisaAd);
            RuleFor(v=>v.soyad).NotEmpty().MinimumLength(3).MaximumLength(60).WithMessage(ValidationMessages.Bos_Girilemez+" veya"+ValidationMessages.KisaSoyad);


        }
    }
}
