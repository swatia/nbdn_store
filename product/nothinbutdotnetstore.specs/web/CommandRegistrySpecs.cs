using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using NUnit.Framework;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class CommandRegistrySpecs
    {
        public class when_finding_a_command_that_can_handle_a_request_and_it_has_the_command : BaseConcern
        {
            RequestCommand command_that_can_process;
            RequestCommand result;
            CommandRegistry sut;
            Request request;
            List<RequestCommand> all_possible;

            protected override void arrange()
            {
                request = mock<Request>();
                command_that_can_process = mock<RequestCommand>();
                all_possible = Enumerable.Range(1, 100).Select(x => mock<RequestCommand>()).ToList();
                all_possible.Add(command_that_can_process);

                command_that_can_process.Stub(x => x.can_process(request)).Return(true);

                sut = new DefaultCommandRegistry(all_possible);
            }

            protected override void act()
            {
                result = sut.get_the_command_that_can_run(request);
            }

            [Test]
            public void should_return_the_command_that_can_process_the_request()
            {
                Assert.AreEqual(command_that_can_process, result);
            }
        }

        public class when_finding_a_command_that_can_handle_a_request_and_it_does_not_have_the_command : BaseConcern
        {
            RequestCommand result;
            CommandRegistry sut;
            Request request;
            List<RequestCommand> all_possible;

            protected override void arrange()
            {
                request = mock<Request>();
                all_possible = Enumerable.Range(1, 100).Select(x => mock<RequestCommand>()).ToList();
                sut = new DefaultCommandRegistry(all_possible);
            }

            protected override void act()
            {
                result = sut.get_the_command_that_can_run(request);
            }

            [Test]
            public void should_return_a_missing_command()
            {
                Assert.IsInstanceOf<MissingRequestCommand>(result);
            }
        }
    }
}