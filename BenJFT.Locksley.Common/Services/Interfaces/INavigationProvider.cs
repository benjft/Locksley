using BenJFT.Locksley.Common.Services.Attributes;

namespace BenJFT.Locksley.Common.Services.Interfaces;

[ServiceLifetime(Lifetime = ServiceLifetime.Singleton)]
public interface INavigationProvider { }