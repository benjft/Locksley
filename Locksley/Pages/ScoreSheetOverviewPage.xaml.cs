using Locksley.ViewModels;

namespace Locksley.Pages;

public partial class ScoreSheetOverviewPage {
    public ScoreSheetOverviewPage(ScoreSheetsOverviewViewModel viewModel) {
        InitializeComponent();
        BindingContext = viewModel;
    }
}