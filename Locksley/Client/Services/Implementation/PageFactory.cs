namespace Locksley.Client.Services.Implementation; 

public class PageFactory(IServiceProvider serviceProvider) : IPageFactory {
    public T CreateNew<T>() where T : Page {
        return serviceProvider.GetRequiredService<T>();
    }

    public TView CreateNew<TView, TViewModel>(TViewModel viewModel)
        where TView : Page, Content.Interfaces.IBuildFromViewModel<TView, TViewModel> 
        where TViewModel : ViewModels.BaseViewModel {
        return TView.Create(viewModel, serviceProvider);
    }
}