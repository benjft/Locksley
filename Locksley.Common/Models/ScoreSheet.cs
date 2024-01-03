namespace Locksley.Common.Models; 

public class ScoreSheet : BaseModel {
    private int _id;
    private string? _title;
    private DateTime? _shotAtUtcDateTime;
    private string? _shotAtLocation;
    private string? _roundName;
    private int _score;
    private double _averageArrow;
    private int _handicapForRound;

    public int Id {
        get => _id;
        set => SetField(ref _id, value);
    }

    public string? Title {
        get => _title;
        set => SetField(ref _title, value);
    }

    public DateTime? ShotAtUtcDateTime {
        get => _shotAtUtcDateTime;
        set => SetField(ref _shotAtUtcDateTime, value);
    }

    public string? ShotAtLocation {
        get => _shotAtLocation;
        set => SetField(ref _shotAtLocation, value);
    }

    public string? RoundName {
        get => _roundName;
        set => SetField(ref _roundName, value);
    }

    public int Score {
        get => _score;
        set => SetField(ref _score, value);
    }

    public double AverageArrow {
        get => _averageArrow;
        set => SetField(ref _averageArrow, value);
    }

    public int HandicapForRound {
        get => _handicapForRound;
        set => SetField(ref _handicapForRound, value);
    }
}