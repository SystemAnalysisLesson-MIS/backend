using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace IkematgahDegisim.Core.Extensions
{
    public static class ConfigureExtension
    {
        public static IConfigurationRoot BuildYourConfiguration(this ConfigurationBuilder configurationBuilder,string pathName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), pathName);
            configurationBuilder.AddJsonFile(path,false);
            return configurationBuilder.Build();
        }
    }
}
