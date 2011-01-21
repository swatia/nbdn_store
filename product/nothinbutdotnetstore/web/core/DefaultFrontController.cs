using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        readonly CommandRegistry command_registry;

        public DefaultFrontController(CommandRegistry command_registry)
        {
            this.command_registry = command_registry;
        }

        public void handle(Request request)
        {
            command_registry.get_the_command_that_can_run(request).run( request);
        }
    }
}