namespace Locksley.Common.Exceptions; 

public class ServiceLifetimeNotFoundException : Exception
{
    public ServiceLifetimeNotFoundException(string message)
        : base(message)
    {
    }
}