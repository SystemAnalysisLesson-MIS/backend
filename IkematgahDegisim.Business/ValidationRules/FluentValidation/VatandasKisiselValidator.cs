using FluentValidation;
using FluentValidation.Validators;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using IkematgahDegisim.Core.Utilities.Constants;

namespace IkematgahDegisim.Business.ValidationRules.FluentValidation
{
    public class VatandasKisiselValidator:AbstractValidator<VatandasKisisel>
    {
        private Regex regex;

        public VatandasKisiselValidator()
        {
            RuleFor(vk => vk.ceptelefonNumarasi)
                .NotEmpty()
                .Must(cepTelefonNumarasi => cepTelefonNumarasi.StartsWith("05") && cepTelefonNumarasi.Length == 11)
                .WithMessage(ValidationMessages.CepTelefonBaslangic + "ya da " + ValidationMessages.KısaGiriş)
                .Custom((cepTelefonNumarasi, context) =>
                {
                    if (!regex.CreatePhoneNumberRegex().VerifyToRegex(cepTelefonNumarasi))
                    {
                        context.AddFailure(ValidationMessages.CepTelefonFormat);
                    }
                });


            RuleFor(vk => vk.email).NotEmpty().EmailAddress(EmailValidationMode.Net4xRegex).WithMessage(ValidationMessages.MailFormat);

            RuleFor(vk => vk.evAdres).NotEmpty().Must(evAdres =>
              evAdres.Contains("Mah.") ||
              evAdres.Contains("MAH.") &&
              evAdres.Contains("No:") ||
              evAdres.Contains("NO:"))
                .WithMessage(ValidationMessages.EvAdresFormat);

           

        }
    }
}
