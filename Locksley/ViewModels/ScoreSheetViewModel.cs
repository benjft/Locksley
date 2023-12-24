using Locksley.Common.Models;

namespace Locksley.ViewModels;

public class ScoreSheetViewModel(ScoreSheet scoreSheet) : BaseViewModel {
    public string Title {
        get => scoreSheet.Title;
        set {
            if (scoreSheet.Title == value) return;
            scoreSheet.Title = value;
            OnPropertyChanged();
        }
    }

    public DateTime ShotAtUtcDateTime {
        get => scoreSheet.ShotAtUtcDateTime;
        set {
            if (scoreSheet.ShotAtUtcDateTime == value) return;
            scoreSheet.ShotAtUtcDateTime = value;
            OnPropertyChanged();
        }
    }

    public string ShotAtLocation {
        get => scoreSheet.ShotAtLocation;
        set {
            if (scoreSheet.ShotAtLocation == value) return;
            scoreSheet.ShotAtLocation = value;
            OnPropertyChanged();
        }
    }

    public string RoundName {
        get => scoreSheet.RoundName;
        set {
            if (scoreSheet.RoundName == value) return;
            scoreSheet.RoundName = value;
            OnPropertyChanged();
        }
    }

    public int Score {
        get => scoreSheet.Score;
        set {
            if (scoreSheet.Score == value) return;
            scoreSheet.Score = value;
            OnPropertyChanged();
        }
    }

    public double AverageArrow {
        get => scoreSheet.AverageArrow;
        set {
            if (Math.Abs(scoreSheet.AverageArrow - value) < double.Epsilon) return;
            scoreSheet.AverageArrow = value;
            OnPropertyChanged();
        }
    }

    public int HandicapForRound {
        get => scoreSheet.HandicapForRound;
        set {
            if (scoreSheet.HandicapForRound == value) return;
            scoreSheet.HandicapForRound = value;
            OnPropertyChanged();
        }
    }
}