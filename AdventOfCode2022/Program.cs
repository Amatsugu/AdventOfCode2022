
using AdventOfCode2022.Day11;
using AdventOfCode2022.Day3;

using System.Diagnostics;

var input = File.ReadAllLines("Day3/input.txt");

var diag = new BinaryDiagnostic(input);
diag.Run();

//var dumbo = new DumboOctopus(input);

//dumbo.Run(1000);

//dumbo.Render();

//Console.Write("Flashes: ");
//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine(dumbo.Flashes);

//Console.ForegroundColor = ConsoleColor.White;

