namespace BenJFT.Locksley.Common.Services.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
public class ServiceLifetimeAttribute : Attribute {
    public required ServiceLifetime Lifetime { get; init; }
}