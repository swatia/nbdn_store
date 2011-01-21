using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_available_commands)
        {
            throw new NotImplementedException();
        }

        public RequestCommand get_the_command_that_can_run(Request request)
        {
            throw new NotImplementedException();
        }
    }
}