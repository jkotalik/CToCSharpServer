using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CToCSharpServer
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder UseCServer(this IWebHostBuilder builder)
        {
            // For cross plat, this check may need to be different
            // We need to check that we have been bootstrapped by the core clr in some way.
            if (NativeMethods.IsCRequestHandlerLoaded())
            {

                return builder.ConfigureServices(services =>
                {
                    services.AddSingleton<IServer, HttpServer>();
                });
            }

            return builder;
        }
    }
}
