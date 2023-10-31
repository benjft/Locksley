namespace Locksley.Exceptions; 

public class ServiceLifetimeNotFoundException : Exception
{
    public ServiceLifetimeNotFoundException(string message)
        : base(message)
    {
    }
}