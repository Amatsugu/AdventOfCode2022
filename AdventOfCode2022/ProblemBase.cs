using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022;

internal interface IProblemBase
{
	public void Setup();

	public void RunPart1();
	public void RunPart2();



	public void Cleanup()
	{

	}
}
