using System.Web;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class RawRequestHandlerSpecs
    {
        public class when_processing_an_incoming_http_context : BaseConcern
        {
            FrontController front_controller;
            Request request;
            RequestFactory request_factory;
            RawRequestHandler sut;
            HttpContext the_actual_http_context;

            protected override void arrange()
            {
                request = mock<Request>();
                request_factory = mock<RequestFactory>();
                the_actual_http_context = ObjectMother.web_items.create_http_context();

                request_factory.Stub(x => x.create_from(the_actual_http_context)).Return(
                    request);

                front_controller = mock<FrontController>();

                sut = new RawRequestHandler(front_controller, request_factory);
            }

            protected override void act()
            {
                sut.ProcessRequest(the_actual_http_context);
            }

            [Test]
            public void should_delegate_the_processing_of_a_request_to_the_front_controller()
            {
                sut.ProcessRequest(the_actual_http_context);

                front_controller.AssertWasCalled(x => x.handle(request));
            }
        }
    }
}