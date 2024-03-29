﻿using Castle.DynamicProxy;
using FluentValidation;
using IkematgahDegisim.Core.CrossCuttingCornces.Validation.FluentValidation;
using IkematgahDegisim.Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IkematgahDegisim.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterceptorBase
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception();
            }

            _validatorType = validatorType;
        }
        public override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                FluentValidationTool.Validate(validator, entity);
            }
        }
    }
}
