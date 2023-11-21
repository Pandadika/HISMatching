namespace Matching.Matching.Algos;
public static class StableMarriage1
{
	public static void StableMarriage(int n, int[,] menPrefs, int[,] womenPrefs)
	{
		int[] womenPartner = new int[n];
		bool[] menFree = new bool[n];

		for (int i = 0; i < n; i++)
		{
			womenPartner[i] = -1; // No woman is initially engaged
			menFree[i] = true;    // All men are initially free
		}

		int freeMenCount = n;
		while (freeMenCount > 0)
		{
			int m;
			for (m = 0; m < n; m++)
			{
				if (menFree[m])
				{
					break;
				}
			}

			for (int i = 0; i < n && menFree[m]; i++)
			{
				int w = menPrefs[m, i];

				if (womenPartner[w] == -1) // Woman w is free
				{
					womenPartner[w] = m;
					menFree[m] = false;
					freeMenCount--;
				}
				else
				{
					int m1 = womenPartner[w];
					if (IsWomanPreferredOverCurrentPartner(m1, m, w, womenPrefs))
					{
						womenPartner[w] = m;
						menFree[m] = false;
						menFree[m1] = true;
					}
				}
			}
		}

		OutputEngagedPairs(womenPartner);
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

	static void OutputEngagedPairs(int[] womenPartner)
	{
		Console.WriteLine("Engaged Pairs (Man, Woman):");
		for (int w = 0; w < womenPartner.Length; w++)
		{
			Console.WriteLine($"({(PlayerName)womenPartner[w]}, {(GameRole)w})");
		}
	}
}
