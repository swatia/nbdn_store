namespace nothinbutdotnetstore.infrastructure
{
    public interface MappingGateway
    {
        ReturnType map<Input, ReturnType>(Input value);
    }
}