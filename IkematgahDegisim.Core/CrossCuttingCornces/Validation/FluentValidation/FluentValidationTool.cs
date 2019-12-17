using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.CrossCuttingCornces.Validation.FluentValidation
{
    public static class FluentValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var result = validator.Validate(entity);

            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    throw new ValidationException(error.ErrorCode + ":" + error.ErrorMessage);
                }
            }
                
        }
    }
}
