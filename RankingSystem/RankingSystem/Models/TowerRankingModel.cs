using System.ComponentModel.DataAnnotations;

namespace RankingSystem.RankingSystem.Models;

public class TowerRankingModel(string name, int score, string version) : IComparable<TowerRankingModel>
{
    [Key] public string Name { get; set; } = name;
    public int Score { get; set; } = score;
    public string Version { get; set; } = version;
    
    public int CompareTo(TowerRankingModel? obj)
    {
        return Score.CompareTo(obj?.Score);
    }
}
public record TowerRankingModelWrapper(IEnumerable<TowerRankingModel> Results);