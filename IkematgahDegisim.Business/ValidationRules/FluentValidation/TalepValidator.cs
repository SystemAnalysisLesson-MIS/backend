using FluentValidation;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.ValidationRules.FluentValidation
{
    public class TalepValidator:AbstractValidator<Talep>
    {
        public TalepValidator()
        {
            RuleFor(t => t.kalinanEvinAdresi)
              .NotEmpty().Must(evAdres =>
              evAdres.Contains("Mah.") ||
              evAdres.Contains("MAH.") &&
              evAdres.Contains("No:") ||
              evAdres.Contains("NO:")).
              WithMessage(ValidationMessages.EvAdresFormat).WithMessage(ValidationMessages.Bos_Girilemez);

            
        }
    }
}
