using Locksley.ViewModels;

namespace Locksley.Pages;

public partial class ScoreSheetOverviewPage {
    public ScoreSheetsOverviewViewModel ViewModel { get; }
    public ScoreSheetOverviewPage(ScoreSheetsOverviewViewModel viewModel) {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
    }

    private bool _loaded = false;
    protected override void OnAppearing() {
        base.OnAppearing();
    
        // Don't load the score sheets until the view is being presented
        if (!_loaded) {
            ScoreSheetsListView.ItemsSource = ViewModel.ScoreSheets;
            _loaded = true;
        }
    }
}