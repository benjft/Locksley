namespace Locksley.Client.Services;

public interface IPageFactory {
    T CreateNew<T>() where T : Page;
    TView CreateNew<TView, TViewModel>(TViewModel viewModel) where TView : Page, Content.Interfaces.IBuildFromViewModel<TView, TViewModel> where TViewModel : ViewModels.BaseViewModel;
}