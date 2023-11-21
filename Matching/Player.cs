using Matching.Extentions;

namespace Matching.Matching;
class Player
{
	public string Name { get; set; }
	public Dictionary<int, GameRole> priorityList { get; set; }

	static Player GeneratePlayer()
	{
		var player = new Player();
		int[] numbers = { 1, 2, 3, 4, 5, 6 };
		var dict = new Dictionary<int, GameRole>();
		var rand = new Random();
		rand.Shuffle(numbers);
		for (int i = 0; i < 6; i++)
		{
			player.priorityList.Add(i, (GameRole)numbers[i]);
		}
		return player;
	}
}
