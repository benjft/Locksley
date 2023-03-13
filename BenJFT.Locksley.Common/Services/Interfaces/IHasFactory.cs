namespace BenJFT.Locksley.Common.Services.Interfaces;

public interface IHasFactory<out T> where T : IHasFactory<T> {
    public static abstract T NewInstance(IServiceProvider services);
}