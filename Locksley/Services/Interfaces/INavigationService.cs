using Locksley.Pages.Interfaces;
using Locksley.ViewModels;

namespace Locksley.Services.Interfaces;

public interface INavigationService {
    Task NavigateToAsync<TView, TViewModel>(TViewModel viewModel)
        where TView : Page, IBuildFromViewModel<TView, TViewModel>
        where TViewModel : BaseViewModel;

    Task NavigateToAsync(Page page);
    Task NavigateBackAsync();
    void RemoveLastFromBackStack();
    void RemoveBackStack();
}