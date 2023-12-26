using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locksley.ViewModels;

namespace Locksley.Pages;

public partial class ScoreSheetOverviewPage {
    public ScoreSheetsOverviewViewModel ViewModel { get; }
    public ScoreSheetOverviewPage(ScoreSheetsOverviewViewModel viewModel) {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
    }
}