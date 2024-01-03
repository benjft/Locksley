using System.ComponentModel;
using Locksley.Common.Models;

namespace Locksley.ViewModels;

public class ScoreSheetListItemViewModel : BaseViewModel, IDisposable {
    private readonly ScoreSheet _scoreSheet;

    private bool _selected;

    public ScoreSheetListItemViewModel(ScoreSheet scoreSheet) {
        _scoreSheet = scoreSheet;
        _selected = (scoreSheet.Id & 1) == 0;

        scoreSheet.PropertyChanged += ScoreSheetOnPropertyChanged;
    }
    
    private void ScoreSheetOnPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        OnPropertyChanged(e.PropertyName);
    }

    public int Id => _scoreSheet.Id;

    public string? Title {
        get => _scoreSheet.Title;
        set {
            if (_scoreSheet.Title == value) return;
            _scoreSheet.Title = value;
            OnPropertyChanged();
        }
    }

    public DateTime? ShotAtUtcDateTime {
        get => _scoreSheet.ShotAtUtcDateTime;
        set {
            if (_scoreSheet.ShotAtUtcDateTime == value) return;
            _scoreSheet.ShotAtUtcDateTime = value;
            OnPropertyChanged();
        }
    }

    public string? ShotAtLocation {
        get => _scoreSheet.ShotAtLocation;
        set {
            if (_scoreSheet.ShotAtLocation == value) return;
            _scoreSheet.ShotAtLocation = value;
            OnPropertyChanged();
        }
    }

    public string? RoundName {
        get => _scoreSheet.RoundName;
        set {
            if (_scoreSheet.RoundName == value) return;
            _scoreSheet.RoundName = value;
            OnPropertyChanged();
        }
    }

    public int Score {
        get => _scoreSheet.Score;
        set {
            if (_scoreSheet.Score == value) return;
            _scoreSheet.Score = value;
            OnPropertyChanged();
        }
    }

    public double AverageArrow {
        get => _scoreSheet.AverageArrow;
        set {
            if (Math.Abs(_scoreSheet.AverageArrow - value) < double.Epsilon) return;
            _scoreSheet.AverageArrow = value;
            OnPropertyChanged();
        }
    }

    public int HandicapForRound {
        get => _scoreSheet.HandicapForRound;
        set {
            if (_scoreSheet.HandicapForRound == value) return;
            _scoreSheet.HandicapForRound = value;
            OnPropertyChanged();
        }
    }

    public bool Selected {
        get => _selected;
        set {
            if (_selected == value) return;
            _selected = value;
            OnPropertyChanged();
        }
    }

    public void Dispose() {
        _scoreSheet.PropertyChanged -= ScoreSheetOnPropertyChanged;
        GC.SuppressFinalize(this);
    }
}