using Flutter.Support.Common.Strings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Flutter.Support.Common.Configurations
{
  public static  class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static AppConfigurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }

        public static IConfigurationRoot Get(string path,string environmentName = null)
        {
            var cacheKey = path + "#" + environmentName;
            return ConfigurationCache.GetOrAdd(cacheKey, _ => BuildConfiguration(path, environmentName));
        }

        private static IConfigurationRoot BuildConfiguration(string path, string environmentName=null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (!environmentName.IsEmpty())
            {
                builder = builder.AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            }
            builder = builder.AddEnvironmentVariables();
            return builder.Build();
        }
    }

}
