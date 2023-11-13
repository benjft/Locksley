namespace Locksley.Common.Models; 

public class ScoreSheet {
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ShotAtUtcDateTime { get; set; }
    public string ShotAtLocation { get; set; }
    public string RoundName { get; set; }
    public int Score { get; set; }
    public double AverageArrow { get; set; }
    public int HandicapForRound { get; set; }
}