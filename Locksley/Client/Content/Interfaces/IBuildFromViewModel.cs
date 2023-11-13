namespace Locksley.Client.Content.Interfaces; 

public interface IBuildFromViewModel<out TView, in TViewModel> 
    where TView : IBuildFromViewModel<TView, TViewModel>
    where TViewModel : ViewModels.BaseViewModel 
{
    public static abstract TView Create(TViewModel viewModel, IServiceProvider serviceProvider);
}