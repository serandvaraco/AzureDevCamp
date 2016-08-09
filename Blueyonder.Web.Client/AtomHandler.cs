using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Blueyonder.Companion.Host
{
    public class AtomHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (request.RequestUri.AbsolutePath.ToLower().Contains("atom"))
            {
                request.Headers.Accept.Clear();
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/atom+xml"));
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}