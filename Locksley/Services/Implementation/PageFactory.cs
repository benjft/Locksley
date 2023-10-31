namespace Locksley.Services.Implementation; 

public class PageFactory(IServiceProvider serviceProvider) : IPageFactory {
    public T CreateNew<T>() where T : Page {
        return serviceProvider.GetRequiredService<T>();
    }
}