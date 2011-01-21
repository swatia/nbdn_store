using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        readonly IEnumerable<RequestCommand> all_available_commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> all_available_commands)
        {
            this.all_available_commands = all_available_commands;
        }

        public RequestCommand get_the_command_that_can_run(Request request)
        {
            RequestCommand command = all_available_commands.FirstOrDefault(x => x.can_process(request));
            if (command == null) command = new MissingRequestCommand();
            return command;
        }
    }
}