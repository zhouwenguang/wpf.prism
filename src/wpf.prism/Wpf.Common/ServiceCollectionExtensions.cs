using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Common
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureServices(this IServiceCollection services)
        {
            services.AddLogging(builder => {
                builder.ClearProviders();
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog("nlog.config");
            });

            return services.BuildServiceProvider();
        }
    }
}
