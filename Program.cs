using Matching.Matching;
using Matching.Matching.Algos;

Dictionary<string, List<GameRole>> preferences = new Dictionary<string, List<GameRole>>
  {
    {"Søren", new List<GameRole>{
      GameRole.Ottomans,
      GameRole.Habsburg,
      GameRole.France,
      GameRole.Pope,
      GameRole.England,
      GameRole.Prots}},
    {"Mads", new List<GameRole>{
      GameRole.Pope,
      GameRole.Prots,
      GameRole.England,
      GameRole.Ottomans,
      GameRole.Habsburg,
      GameRole.France}},
    {"Charlotte", new List<GameRole>{
      GameRole.Ottomans,
      GameRole.France,
      GameRole.England,
      GameRole.Habsburg,
      GameRole.Prots,
      GameRole.Pope}},
    {"Anne", new List<GameRole>{
      GameRole.Prots,
      GameRole.Pope,
      GameRole.France,
      GameRole.England,
      GameRole.Ottomans,
      GameRole.Habsburg}},
    {"Patrick", new List<GameRole>{
      GameRole.France,
      GameRole.England,
      GameRole.Pope,
      GameRole.Habsburg,
      GameRole.Prots,
      GameRole.Ottomans}},
    {"Simon", new List<GameRole>{
      GameRole.Habsburg,
      GameRole.Ottomans,
      GameRole.France,
      GameRole.England,
      GameRole.Pope,
      GameRole.Prots}}
  };

var solver = new RankMaximalMatchingSolver(preferences);
var matching = solver.FindRankMaximalMatching();

Console.WriteLine("Rank-Maximal Matching:");
foreach (var pair in matching)
{
  Console.WriteLine($"{pair.Key} -> {pair.Value}");
}
