namespace Matching.Matching.Algos;
public class RankMaximalMatchingSolver
{
	private Dictionary<string, List<GameRole>> preferences;

	public RankMaximalMatchingSolver(Dictionary<string, List<GameRole>> preferences)
	{
		this.preferences = preferences;
	}

	public Dictionary<string, GameRole> FindRankMaximalMatching()
	{
		Dictionary<string, GameRole> matching = new Dictionary<string, GameRole>();
		List<string> unassignedApplicants = new List<string>(preferences.Keys);

		bool improved = true;

		while (improved)
		{
			improved = false;

			foreach (var applicant in unassignedApplicants.ToList())
			{
				foreach (var choice in preferences[applicant])
				{
					if (!matching.ContainsValue(choice))
					{
						matching[applicant] = choice;
						improved = true;
						unassignedApplicants.Remove(applicant);
						break;
					}
				}
			}
		}

		return matching;
	}
}