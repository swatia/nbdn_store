namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand 
    {
        void run(Request request);
        bool can_process(Request request);
    }
}