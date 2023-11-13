namespace Locksley.Common.Attributes; 

[AttributeUsage(AttributeTargets.Class)]
public class ServiceLifetimeAttribute(ServiceLifetime lifetime) : Attribute {
    public ServiceLifetime ServiceLifetime => lifetime;
}