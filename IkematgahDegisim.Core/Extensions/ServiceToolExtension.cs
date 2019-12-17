using IkematgahDegisim.Core.Utilities.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Extensions
{
    public static class ServiceToolExtension
    {
        public static IServiceCollection AddDepencyResolver(this IServiceCollection services,ICoreModule[] modules)
        {
            foreach(var module in modules)
            {
                module.Load(services);
            }

            return ServiceTool.Create(services);
        }
    }
}
