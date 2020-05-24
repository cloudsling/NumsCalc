using System;
using System.Collections.Generic;

namespace NumCalc
{
	class Program
	{
		static void Main(string[] args)
		{
			//double except = 464808;
			double expect = 1430540;//755920;

			var atomList = new List<double>{
				   11900,17000,13900,19700,13900
				};

			Test(atomList);

			var calc = new Calculator(expect, atomList);

			Console.WriteLine("Starting...");
			var calculated = calc.Calculate();

			if (calculated != null)
			{
				foreach (var item in calculated)
					Console.WriteLine(item);

				Console.Read();
			}
		}

		public static void Test(List<double> atomList)
		{
			var utData = UnitTest.Data();
			double sums = 0.0;
			for (int i = 0; i < utData.Count; i++)
			{
				sums += utData[i] * atomList[i];
			}
			Console.WriteLine();
		}
	}
}
