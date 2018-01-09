using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CToCSharpServer
{
    class CHttpContextOfT<TContext> : CHttpContext
    {
        private IntPtr pHttpContext;
        private IHttpApplication<TContext> _application;

        public CHttpContextOfT(IHttpApplication<TContext> application, IntPtr pHttpContext)
            : base (pHttpContext)
        {
            _application = application;
        }

        public async Task ProcessRequestAsync()
        {
            var context = default(TContext);
            try
            {
                context = _application.CreateContext(this);
            }
            catch (Exception ex)
            {

            }
            // TODO fancy stuff with cleaning up the request
        }
    }
}
