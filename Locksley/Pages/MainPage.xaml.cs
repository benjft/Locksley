using Locksley.Resources.Strings;
using Locksley.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Locksley.Pages;

public partial class MainPage {
    private readonly IPageFactory _pageFactory;
    private readonly ILogger _logger;

    public MainPage(IPageFactory pageFactory, ILogger<MainPage> logger) {
        _pageFactory = pageFactory;
        _logger = logger;
        AddSubPages();
        InitializeComponent();
        
        _logger.LogInformation("Main Page Created");
    }

    private void AddSubPages() {
        var scoreSheetsPage = _pageFactory.CreateNew<ScoreSheetOverviewPage>();
        _logger.LogInformation("Adding Children");
        Children.Add(new NavigationPage(scoreSheetsPage) { Title = AppResources.ScoreSheets });
    }
}