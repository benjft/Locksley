using Locksley.Common.Attributes;
using Locksley.Pages.Interfaces;
using Locksley.Services.Interfaces;
using Locksley.ViewModels;

namespace Locksley.Services;

[ServiceLifetime(ServiceLifetime.Singleton)]
public class NavigationService(IPageFactory pageFactory) : INavigationService {

    private static Application CurrentApplication => Application.Current;

    public Task NavigateToAsync<TView, TViewModel>(TViewModel viewModel)
        where TView : Page, IBuildFromViewModel<TView, TViewModel>
        where TViewModel : BaseViewModel {
        var page = pageFactory.CreateNew<TView, TViewModel>(viewModel);
        
        return NavigateToAsync(page);
    }

    public Task NavigateToAsync(Page page) {
        return InternalNavigateToAsync(page);
    }

    public Task NavigateBackAsync() {
        if (CurrentApplication.MainPage is not NavigationPage navigationPage) {
            throw new Exception("The current page is not a NavigationPage");
        }

        return navigationPage.Navigation.PopAsync();
    }

    public void RemoveLastFromBackStack() {
        if (CurrentApplication.MainPage is not NavigationPage navigationPage) {
            throw new Exception("The current page is not a NavigationPage");
        }

        navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack[^2]);
    }

    public void RemoveBackStack() {
        if (CurrentApplication.MainPage is not NavigationPage navigationPage) {
            throw new Exception("The current page is not a NavigationPage");
        }

        for (var i = 0; i < navigationPage.Navigation.NavigationStack.Count - 1; i++) {
            navigationPage.Navigation.RemovePage(navigationPage.Navigation.NavigationStack[i]);
        }
    }

    private static async Task InternalNavigateToAsync(Page page) {
        if (CurrentApplication.MainPage is NavigationPage navigationPage) {
            await navigationPage.PushAsync(page);
        } else {
            CurrentApplication.MainPage = new NavigationPage(page);
        }
    }
}