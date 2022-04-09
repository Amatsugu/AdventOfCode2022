using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6;

internal class LanternFish : ProblemBase
{
	public int[] Data { get; init; }

	public LanternFish()
	{
		var input = File.ReadAllLines("Day6/input.txt");
		Data = input.First().Split(",").Select(v => int.Parse(v)).ToArray();	
	}


	public override void RunPart1()
	{
		var lifetimes = PrepareLifetimes();
		var fish = Simulate(lifetimes, 80);

		Console.WriteLine($"Fish 80 Days: {fish}");
	}
	public override void RunPart2()
	{
		var lifetimes = PrepareLifetimes();
		var fish = Simulate(lifetimes, 256);

		Console.WriteLine($"Fish 256 Days: {fish}");
	}

	private long[] PrepareLifetimes()
	{
		var lifetimes = new long[9];
		foreach (var life in Data)
			lifetimes[life] += 1;

		return lifetimes;
	}

	private long Simulate(long[] lifetimes, int days)
	{
		for (int i = 0; i < days; i++)
		{
			var day0Count = lifetimes[0];
			for (int j = 1; j < lifetimes.Length; j++)
				lifetimes[j-1] = lifetimes[j];
			lifetimes[6] += day0Count;
			lifetimes[lifetimes.Length-1] = day0Count;
		}

		return lifetimes.Sum();
	}


}
