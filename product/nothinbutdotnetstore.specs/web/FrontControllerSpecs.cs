using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class FrontControllerSpecs
    {
        public class when_processing_an_incoming_request : BaseConcern
        {
            RequestCommand command_that_can_process_request;
            Request request;
            FrontController sut;
            CommandRegistry command_registry;

            protected override void arrange()
            {
                command_that_can_process_request = mock<RequestCommand>();
                request = mock<Request>();
                command_registry = mock<CommandRegistry>();

                command_registry.Stub(x => x.get_the_command_that_can_run(request)).Return(
                    command_that_can_process_request);

                sut = new DefaultFrontController(command_registry);
            }

            protected override void act()
            {
                sut.handle(request);
            }

            [Test]
            public void should_delegate_the_processing_to_the_command_that_can_process_the_request()
            {
                command_that_can_process_request.AssertWasCalled(x => x.run(request));
            }
        }
    }
}