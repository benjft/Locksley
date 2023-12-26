using System.Collections.ObjectModel;

namespace Locksley.ViewModels; 

public class ScoreSheetsOverviewViewModel : BaseViewModel {
    public ObservableCollection<ScoreSheetViewModel> ScoreSheets = [];
    
    
}