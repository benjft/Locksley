using Locksley.Pages;
using Locksley.Services.Interfaces;

namespace Locksley;

public partial class App : Application {
    public App(IPageFactory pageFactory) {
        InitializeComponent();

        var mainPage = pageFactory.CreateNew<MainPage>();
        MainPage = new NavigationPage(mainPage);
    }
}