using Locksley.Common.Models;

namespace Locksley.Data.Repositories; 

public interface IScoreSheetRepository {
    IEnumerable<ScoreSheet> ScoreSheets { get; }
    ScoreSheet GetById(int id);
    void SaveChanges();
}