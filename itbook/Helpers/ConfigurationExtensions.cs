using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace itbook.Helpers
{
    // Helper class to get configuration values
    public static class ConfigurationExtensions
    {
        // Get configuration value, throw exception if not set
        public static string GetRequiredConfig(this IConfiguration configuration, string key)
        {
            var value = Environment.GetEnvironmentVariable(key) ?? configuration[key];
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException(
                    $"{key} is not set in the environment or configuration."
                );
            }
            return value;
        }
    }
}
