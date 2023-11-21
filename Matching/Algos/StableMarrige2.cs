namespace Matching.Matching.Algos;

public static class StableMarriage2
{
	public static List<Tuple<int, int>> StableMarriage(int n, int[,] menPrefs, int[,] womenPrefs)
	{
		int[] womenPartner = new int[n];
		bool[] menFree = new bool[n];
		List<Tuple<int, int>> engagedPairs = new List<Tuple<int, int>>();

		for (int i = 0; i < n; i++)
		{
			womenPartner[i] = -1; // No woman is initially engaged
			menFree[i] = true;    // All men are initially free
		}

		while (true)
		{
			int m = FindFreeMan(menFree);
			if (m == -1)
			{
				break;
			}

			for (int i = 0; i < n; i++)
			{
				int w = menPrefs[m, i];

				if (womenPartner[w] == -1)
				{
					// Woman w is free
					womenPartner[w] = m;
					menFree[m] = false;
					engagedPairs.Add(new Tuple<int, int>(m, w));
					break;
				}
				else
				{
					int m1 = womenPartner[w];
					if (IsWomanPreferredOverCurrentPartner(m1, m, w, womenPrefs))
					{
						womenPartner[w] = m;
						menFree[m] = false;
						menFree[m1] = true;
						engagedPairs.Remove(new Tuple<int, int>(m1, w));
						engagedPairs.Add(new Tuple<int, int>(m, w));
						break;
					}
				}
			}
		}

		OutputEngagedPairs(engagedPairs);

		return engagedPairs;
	}

	static void OutputEngagedPairs(List<Tuple<int, int>> womenPartner)
	{
		Console.WriteLine("Engaged Pairs (Man, Woman):");
		for (int w = 0; w < womenPartner.Count; w++)
		{
			Console.WriteLine($"({(PlayerName)womenPartner[w].Item1}, {(GameRole)womenPartner[w].Item2})");
		}
	}

	static int FindFreeMan(bool[] menFree)
	{
		for (int m = 0; m < menFree.Length; m++)
		{
			if (menFree[m])
			{
				return m;
			}
		}
		return -1;
	}

	static bool IsWomanPreferredOverCurrentPartner(int m1, int m, int w, int[,] womenPrefs)
	{
		for (int i = 0; i < womenPrefs.GetLength(1); i++)
		{
			if (womenPrefs[w, i] == m)
			{
				return true;
			}
			if (womenPrefs[w, i] == m1)
			{
				return false;
			}
		}
		return false;
	}
}
