using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.Features;

namespace CToCSharpServer
{
    class HttpServer : IServer
    {
        private GCHandle _httpServerHandle;

        public IFeatureCollection Features => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            _httpServerHandle = GCHandle.Alloc(this);

            NativeMethods.RegisterCallbacks();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private static bool HandleRequest(IntPtr pHttpContext, IntPtr pvRequestContext)
        {
            var server = (HttpServer)GCHandle.FromIntPtr(pvRequestContext).Target;

            var context = new CHttpContext(pHttpContext);

            var task = context.ProcessRequestAsync();


            return true;
        }
    }
}