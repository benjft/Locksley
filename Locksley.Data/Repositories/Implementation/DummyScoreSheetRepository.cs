using Locksley.Common.Attributes;
using Locksley.Common.Models;
using Microsoft.Extensions.Logging;

namespace Locksley.Data.Repositories.Implementation; 

[ServiceLifetime(ServiceLifetime.Singleton)]
public class DummyScoreSheetRepository(ILogger<DummyScoreSheetRepository> logger) : IScoreSheetRepository {
    private Dictionary<int, ScoreSheet> _scoreSheets = 
        Enumerable.Range(1, 10)
        .ToDictionary(i => i, i => new ScoreSheet {
            Id = i,
            Title = $"Score Sheet {i}",
            ShotAtUtcDateTime = DateTime.Parse("2023-11-01").AddDays(i),
            ShotAtLocation = null,
            RoundName = (i & 1) == 0 ? "Portsmouth" : "WA 18",
            Score = 600 - i,
            AverageArrow = (600d - i) / 60d,
            HandicapForRound = -i,
        });

    public IEnumerable<ScoreSheet> ScoreSheets => _scoreSheets.Values.OrderBy(v => v.Id);
    
    public ScoreSheet GetById(int id) => _scoreSheets[id];

    public void SaveChanges() {
        logger.LogInformation("DUMMY CHANGED CAN'T BE SAVED, DUMMY");
    }
}