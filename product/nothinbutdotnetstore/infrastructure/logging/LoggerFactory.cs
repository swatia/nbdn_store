using System;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public interface LoggerFactory
    {
        Logger create_logger_for(Type type_that_requested_logging_services);
    }
}