using Locksley.Pages.Interfaces;
using Locksley.ViewModels;

namespace Locksley.Services.Interfaces;

public interface IPageFactory {
    T CreateNew<T>() where T : Page;
    TView CreateNew<TView, TViewModel>(TViewModel viewModel) 
        where TView : Page, IBuildFromViewModel<TView, TViewModel> 
        where TViewModel : BaseViewModel;
}