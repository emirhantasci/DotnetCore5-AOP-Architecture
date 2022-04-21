using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using EmirApi.Core.CrossCuttingConcerns.Caching;
using EmirApi.Core.CrossCuttingConcerns.Caching.Microsoft;
using EmirApi.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using EmirApi.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace EmirApi.Core.DependencyResolvers
{
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<FileLogger>();
        }
    }
}
