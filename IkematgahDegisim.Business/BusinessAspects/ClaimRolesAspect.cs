using Castle.DynamicProxy;
using IkematgahDegisim.Core.Extensions;
using IkematgahDegisim.Core.Utilities.Interceptors;
using IkematgahDegisim.Core.Utilities.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.BusinessAspects
{
    public class ClaimRolesAspect:MethodInterceptorBase
    {
        private string[] roles;
        private IHttpContextAccessor httpContextAccessor;
        


        public ClaimRolesAspect(string role)
        {
            roles = role.Split(',');
            httpContextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }

        public override void OnBefore(IInvocation invocation)
        {
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception();
        }
    }
}
