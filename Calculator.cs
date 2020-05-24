using System;
using System.Collections.Generic;

namespace NumCalc
{
	internal class Calculator
	{
		private static double DELTA = 0.01;

		private static Random Ran;

		private double Expected { get; set; }

		private List<double> AtomList { get; set; }

		private List<double> DeltaList { get; set; }

		public Calculator(double expected, List<double> atomList)
		{
			Expected = expected;
			AtomList = atomList;

			var statusCode = InputCheck();
			if (statusCode != StatusCode.OK)
			{
				// TODO: custom exception
				throw new InvalidCastException();
			}

			DeltaList = new List<double>();
			InitDelta(AtomList.Count);
		}

		public List<double> Calculate()
		{
			while (true)
			{
				int cnt = AtomList.Count;
				InitDelta(cnt);
				Ran = new Random();
				int oneCum;

				while (true)
				{
					oneCum = Ran.Next(0, AtomList.Count);
					DeltaList[oneCum] += DELTA;

					double sums = Sums(AtomList, DeltaList);
					if (sums > Expected)
					{
						if (sums - Expected < 0.01)
						{
							return DeltaList;
						}
						break;
					}
					if (Expected - sums < 0.01)
					{
						return DeltaList;
					}
				}
			}
		}

		private void InitDelta(int count)
		{
			DeltaList.Clear();
			Random Ran = new Random();
			for (int i = 0; i < count; i++)
			{
				double delta = Ran.Next(0, 10) / 10;
				DeltaList.Add(1 + delta);
			}
		}

		private double Sums(List<double> atom, List<double> delta)
		{
			double sum = 0.0;

			for (int i = 0; i < atom.Count; i++)
				sum += atom[i] * delta[i];

			return sum;
		}
		private StatusCode InputCheck()
		{
			if (Expected <= 0)
			{
				return StatusCode.ERR_EXPECTED;
			}
			if (AtomList == null || AtomList.Count == 0)
			{
				return StatusCode.NULL_LIST;
			}
			return StatusCode.OK;
		}
	}
}