namespace Locksley.Services;

public interface IPageFactory {
    T CreateNew<T>() where T : Page;
}