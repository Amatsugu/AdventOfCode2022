
using AdventOfCode2022.Day11;

using System.Diagnostics;

var input = File.ReadAllLines("Day11/input.txt");

var dumbo = new DumboOctopus(input);

dumbo.Run(1000);

dumbo.Render();

Console.Write("Flashes: ");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine(dumbo.Flashes);

Console.ForegroundColor = ConsoleColor.White;

