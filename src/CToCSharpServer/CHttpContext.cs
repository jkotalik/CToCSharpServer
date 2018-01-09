using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;

namespace CToCSharpServer
{
    public partial class CHttpContext : IDisposable
    {
        public string HttpVersion { get; set; }
        public string Scheme { get; set; }
        public string Method { get; set; }
        public string PathBase { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RawTarget { get; set; }
        public int StatusCode { get; set; } = 200;
        public string ReasonPhrase { get; set; }
        public CancellationToken RequestAborted { get; set; }
        public bool HasResponseStarted { get; set; }

        public Stream RequestBody { get; set; }
        public Stream ResponseBody { get; set; }


        public IHeaderDictionary RequestHeaders { get; set; }
        public IHeaderDictionary ResponseHeaders { get; set; } = new HeaderDictionary();


        public void Dispose()
        {
        }
    }
}