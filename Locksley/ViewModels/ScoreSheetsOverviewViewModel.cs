using System.Collections.ObjectModel;
using Locksley.Data.Repositories.Interfaces;

namespace Locksley.ViewModels; 

public class ScoreSheetsOverviewViewModel(IScoreSheetRepository scoreSheetRepository) : BaseViewModel {
    public ObservableCollection<ScoreSheetViewModel> ScoreSheets { get; } =
        new(scoreSheetRepository.ScoreSheets.Select(s => new ScoreSheetViewModel(s)));
}