using System.ComponentModel;
using Locksley.Common.Models;

namespace Locksley.Data.Repositories.Interfaces; 

public interface IScoreSheetRepository : INotifyPropertyChanged {
    IEnumerable<ScoreSheet> ScoreSheets { get; }
    ScoreSheet GetById(int id);
    void SaveChanges();
    ScoreSheet New();
    bool Delete(ScoreSheet scoreSheet);
}