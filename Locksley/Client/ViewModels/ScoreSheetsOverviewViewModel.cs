using System.Collections.ObjectModel;

namespace Locksley.Client.ViewModels; 

public class ScoreSheetsOverviewViewModel : BaseViewModel {
    public ObservableCollection<ScoreSheetViewModel> ScoreSheets = new();
    
    
}