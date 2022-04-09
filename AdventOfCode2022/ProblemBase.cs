using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022;

public abstract class ProblemBase
{

	public abstract void RunPart1();
	public abstract void RunPart2();



	public virtual void Cleanup()
	{

	}
}
