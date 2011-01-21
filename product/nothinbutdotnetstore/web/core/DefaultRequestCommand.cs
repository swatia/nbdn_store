using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequestCommand : RequestCommand
    {
        RequestCriteria criteria;

        public DefaultRequestCommand(RequestCriteria criteria)
        {
            this.criteria = criteria;
        }

        public void run(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            return criteria.Invoke(request);
        }
    }
}