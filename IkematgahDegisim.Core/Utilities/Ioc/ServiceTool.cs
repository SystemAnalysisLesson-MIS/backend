using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Ioc
{
    public static class ServiceTool
    {
        public static IServiceProvider serviceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection serviceCollection)
        {
            serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceCollection;
        }
    }
}
