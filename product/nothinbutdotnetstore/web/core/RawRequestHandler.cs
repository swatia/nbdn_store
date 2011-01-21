using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawRequestHandler : IHttpHandler
    {
        public RawRequestHandler(FrontController front_controller, RequestFactory request_factory)
        {
            throw new NotImplementedException();
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}