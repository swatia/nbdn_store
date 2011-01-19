using System;
using System.Diagnostics;

namespace nothinbutdotnetstore.infrastructure.logging
{
    public class Log
    {
        public static LogFactoryResolver factory_resolver = () =>
        {
            throw new NotImplementedException("This needs to be set at configuration runtime");
        };

        public static Logger an
        {
            get { return factory_resolver().create_logger_for(resolve_the_calling_type());}
        }

        static Type resolve_the_calling_type()
        {
            return new StackFrame(2).GetMethod().DeclaringType;
        }
    }
}