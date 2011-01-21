using System;
using System.Web.UI.WebControls;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;

namespace nothinbutdotnetstore.specs.web
{
    public class RequestCommandSpecs
    {
        public class when_determining_if_it_can_process_a_request : BaseConcern
        {
            bool result;
            RequestCommand sut;
            Request request;
            Request request_used;

            protected override void arrange()
            {
                request = mock<Request>();
                sut = new DefaultRequestCommand(x =>
                {
                    request_used = x;
                    return true;
                });
            }

            protected override void act()
            {
                result = sut.can_process(request);
            }

            
            [Test]
            public void should_make_the_determination_by_using_the_request_criteria()
            {
                Assert.IsTrue(result);
                Assert.AreEqual(request,request_used);
            }
        } 
    }
}