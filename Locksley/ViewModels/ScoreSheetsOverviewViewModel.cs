using System.Collections.ObjectModel;
using System.ComponentModel;
using Locksley.Data.Repositories.Interfaces;

namespace Locksley.ViewModels; 

public class ScoreSheetsOverviewViewModel : BaseViewModel {
    public ObservableCollection<ScoreSheetListItemViewModel> ScoreSheets { get; } = [];
    
    public ScoreSheetsOverviewViewModel(IScoreSheetRepository scoreSheetRepository) {
        UpdateScoreSheets(scoreSheetRepository);
        scoreSheetRepository.PropertyChanged += ScoreSheetRepositoryOnPropertyChanged;    
    }

    private void ScoreSheetRepositoryOnPropertyChanged(object sender, PropertyChangedEventArgs e) {
        if (sender is not IScoreSheetRepository scoreSheetRepository) {
            throw new Exception("Expected this to be called by an IScoreSheetRepository");
        }

        if (e.PropertyName != nameof(scoreSheetRepository.ScoreSheets)) 
            return;
        
        UpdateScoreSheets(scoreSheetRepository);
    }

    private void UpdateScoreSheets(IScoreSheetRepository scoreSheetRepository) {
        ScoreSheets.Clear();
        foreach (var scoreSheet in scoreSheetRepository.ScoreSheets) {
            ScoreSheets.Add(new ScoreSheetListItemViewModel(scoreSheet));
        }
    }
}