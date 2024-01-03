using Locksley.Pages;
using Locksley.Services.Interfaces;

namespace Locksley;

public partial class App {
    public App(IPageFactory pageFactory) {
        InitializeComponent();

        MainPage = pageFactory.CreateNew<MainPage>();
    }
}