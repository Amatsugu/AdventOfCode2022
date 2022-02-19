using System.Collections;
using System.Text;

namespace AdventOfCode2022.Day11;

public class DumboOctopus : IEnumerable<byte>
{
	public byte[] Data { get; init; }
	public int Flashes { get; private set; }

	public DumboOctopus(string[] data)
	{
		Data = new byte[10 * 10];
		if (data.Length != 10)
			throw new ArgumentException("Data must contain 10 elements", nameof(data));
		for (int y = 0; y < data.Length; y++)
		{
			var line = data[y];
			if (line.Length != 10)
				throw new ArgumentException($"Lines must contain 10 elements. Line: {y + 1}", nameof(data));

			for (int x = 0; x < line.Length; x++)
			{
				Data[x + y * 10] = byte.Parse(line.Substring(x, 1));
			}
		}
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return ((IEnumerable<byte>)Data).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return Data.GetEnumerator();
	}

	public void Run(int count)
	{
		for (int i = 0; i < count; i++)
		{
			var start = Flashes;
			Run();
			if (Flashes - start == 100)
				Console.WriteLine($"Full Flash: {i+1}");
		}
	}

	public void Run()
	{
		Increment();
		Flash();

	}

	private void Increment()
	{
		for (int i = 0; i < Data.Length; i++)
			Data[i]++;
	}

	private void Flash()
	{
		var diff = 0;
		do
		{
			var startFlash = Flashes;
			for (int i = 0; i < Data.Length; i++)
			{
				if (Data[i] > 9)
					PerformFlash(i);
			}
			diff = Flashes - startFlash;
		}while (diff != 0);
	}

	private void PerformFlash(int index)
	{
		Flashes++;
		var y = index / 10;
		var x = index % 10;

		Data[index] = 0;

		if (x > 0)
		{
			//Left
			index = (x - 1) + y * 10;
			if (index >= 0 && Data[index] != 0)
				Data[index]++;
		}
		if (x < 9)
		{
			//Right
			index = (x + 1) + y * 10;
			if (index < Data.Length && Data[index] != 0)
				Data[index]++;
		}
		if (y > 0)
		{
			//Up
			index = (x + 0) + (y - 1) * 10;
			if (index >= 0 && Data[index] != 0)
				Data[index]++;
			if (x > 0)
			{
				//Up Left
				index = (x - 1) + (y - 1) * 10;
				if (index >= 0 && Data[index] != 0)
					Data[index]++;
			}
			if (x < 9)
			{
				//Up Right
				index = (x + 1) + (y - 1) * 10;
				if (index < Data.Length && Data[index] != 0)
					Data[index]++;
			}
		}

		if (y < 9)
		{
			//Bottom
			index = (x + 0) + (y + 1) * 10;
			if (index < Data.Length && Data[index] != 0)
				Data[index]++;
			if (x > 0)
			{
				//Bottom Left
				index = (x - 1) + (y + 1) * 10;
				if (index < Data.Length && Data[index] != 0)
					Data[index]++;
			}
			if (x < 9)
			{
				//Bottom Right
				index = (x + 1) + (y + 1) * 10;
				if (index < Data.Length && Data[index] != 0)
					Data[index]++;
			}
		}
	}

	public override string ToString()
	{
		var output = new StringBuilder();
		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				output.Append(Data[x + y * 10]);
			}
			output.AppendLine();
		}
		return output.ToString();
	}

	public void Render()
	{
		for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 10; x++)
			{
				var index = x + y * 10;
				if (Data[index] == 0)
					Console.ForegroundColor = ConsoleColor.Magenta;
				else
					Console.ForegroundColor = ConsoleColor.White;
				Console.Write(Data[index]);
			}
			Console.WriteLine();
		}
	}
}