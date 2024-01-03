using Locksley.Common.Attributes;
using Locksley.Common.Models;
using Locksley.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Locksley.Data.Repositories; 

[ServiceLifetime(ServiceLifetime.Singleton)]
public class DummyScoreSheetRepository(ILogger<DummyScoreSheetRepository> logger) : BaseRepository, IScoreSheetRepository {
    private readonly Dictionary<int, ScoreSheet> _scoreSheets = 
        Enumerable.Range(1, 10)
        .ToDictionary(i => i, NewScoreSheetFromId);

    private static ScoreSheet NewScoreSheetFromId(int i) =>
        new() {
            Id = i,
            Title = $"Score Sheet {i}",
            ShotAtUtcDateTime = DateTime.Parse("2023-11-01").AddDays(i),
            ShotAtLocation = null,
            RoundName = (i & 1) == 0 ? "Portsmouth" : "WA 18",
            Score = 600 - i,
            AverageArrow = (600d - i) / 60d,
            HandicapForRound = -i,
        };

    public IEnumerable<ScoreSheet> ScoreSheets => _scoreSheets.Values.OrderBy(v => v.Id);
    
    public ScoreSheet GetById(int id) => _scoreSheets[id];

    public void SaveChanges() {
        logger.LogWarning("DUMMY CHANGED CAN'T BE SAVED, DUMMY");
    }

    public ScoreSheet New() {
        var scoreSheet = NewScoreSheetFromId(_scoreSheets.Keys.Max() + 1);
        _scoreSheets.Add(scoreSheet.Id, scoreSheet);
        
        logger.LogInformation("Created new score sheet with id {Id}", scoreSheet.Id);
        
        OnPropertyChanged(nameof(ScoreSheets));
        return scoreSheet;
    }

    public bool Delete(ScoreSheet scoreSheet) {
        if (!_scoreSheets.TryGetValue(scoreSheet.Id, out var value) || value != scoreSheet) {
            return false;
        }

        return _scoreSheets.Remove(scoreSheet.Id);
    }
}