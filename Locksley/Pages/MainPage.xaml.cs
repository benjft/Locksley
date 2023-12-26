using Locksley.Resources.Strings;
using Locksley.Services.Interfaces;

namespace Locksley.Pages;

public partial class MainPage {
    private readonly IPageFactory _pageFactory;

    public MainPage(IPageFactory pageFactory) {
        _pageFactory = pageFactory;
        AddSubPages();
        InitializeComponent();
    }

    private void AddSubPages() {
        var scoreSheetsPage = _pageFactory.CreateNew<ScoreSheetOverviewPage>();
        
        Children.Add(new NavigationPage(scoreSheetsPage) { Title = AppResources.ScoreSheets });
    }
}