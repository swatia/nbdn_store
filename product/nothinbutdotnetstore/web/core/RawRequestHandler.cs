using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawRequestHandler : IHttpHandler
    {
        protected RequestFactory request_factory { get; set; }
        protected FrontController front_controller { get; set; }


        public RawRequestHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.handle(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }
    }
}