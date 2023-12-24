using Locksley.Common.Attributes;
using Locksley.Pages.Interfaces;
using Locksley.Services.Interfaces;
using Locksley.ViewModels;

namespace Locksley.Services; 

[ServiceLifetime(ServiceLifetime.Singleton)]
public class PageFactory(IServiceProvider serviceProvider) : IPageFactory {
    public T CreateNew<T>() where T : Page {
        return serviceProvider.GetRequiredService<T>();
    }

    public TView CreateNew<TView, TViewModel>(TViewModel viewModel)
        where TView : Page, IBuildFromViewModel<TView, TViewModel> 
        where TViewModel : BaseViewModel {
        return TView.Create(viewModel, serviceProvider);
    }
}