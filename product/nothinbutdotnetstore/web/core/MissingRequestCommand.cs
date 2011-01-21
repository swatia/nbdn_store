using System;

namespace nothinbutdotnetstore.web.core
{
    public class MissingRequestCommand:RequestCommand
    {
        public void run(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}