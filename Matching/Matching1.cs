using Matching.Matching.Algos;

namespace Matching.Matching;
internal class Matching1
{
	public Matching1()
	{
		var rand = new Random();
		int[] numbers = { 0, 1, 2, 3, 4, 5 };

		List<int[]> menPrefs = new()
		{
			new[] { 0, 1, 2, 3, 5, 4 },
			new[] { 0, 1, 2, 3, 4, 5 },
			new[] { 0, 1, 2, 3, 4, 5 },
			new[] { 0, 1, 2, 3, 4, 5 },
			new[] { 0, 1, 2, 3, 4, 5 },
			new[] { 0, 1, 2, 3, 4, 5 }
		};


		int n = 6; // Number of men/women

		int[,] womenPrefs = { };

		int[,] array = CreateRectangularArray(menPrefs);

		int[,] array2 =
		{
			{ 0, 5, 3, 2, 1, 4 },
			{ 2, 1, 0, 3, 4, 5 },
			{ 0, 1, 2, 3, 4, 5 },
			{ 0, 1, 2, 3, 4, 5 },
			{ 0, 1, 2, 3, 4, 5 },
			{ 0, 1, 2, 3, 4, 5 }
		};

		StableMarriage1.StableMarriage(n, array2, womenPrefs);

		List<Tuple<int, int>> engagedPairs = StableMarriage2.StableMarriage(n, array2, womenPrefs);
		if (engagedPairs.Count == n)
		{
			Console.WriteLine("The engagement relation is a super-stable matching.");
		}
		else
		{
			Console.WriteLine("No strongly stable matching exists.");
		}
	}

	static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
	{
		// TODO: Validation and special-casing for arrays.Count == 0
		int minorLength = arrays[0].Length;
		T[,] ret = new T[arrays.Count, minorLength];
		for (int i = 0; i < arrays.Count; i++)
		{
			var array = arrays[i];
			if (array.Length != minorLength)
			{
				throw new ArgumentException
						("All arrays must be the same length");
			}
			for (int j = 0; j < minorLength; j++)
			{
				ret[i, j] = array[j];
			}
		}
		return ret;
	}
}
