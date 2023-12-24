using Locksley.Common.Models;

namespace Locksley.Data.Repositories.Interfaces; 

public interface IScoreSheetRepository {
    IEnumerable<ScoreSheet> ScoreSheets { get; }
    ScoreSheet GetById(int id);
    void SaveChanges();
}