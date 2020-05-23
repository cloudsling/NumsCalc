using System;
using System.Collections.Generic;

namespace NumCalc
{
	internal class Calculator
	{
		private static double DETAL = 0.01;

		private static Random Ran;

		private double Expected { get; set; }

		private List<double> AtomList { get; set; }

		private List<double> DetalList { get; set; }

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

			DetalList = new List<double>();
			InitDetal(AtomList.Count);
		}

		public List<double> Calculcate()
		{
			while (true)
			{
				int cnt = AtomList.Count;
				InitDetal(cnt);
				Ran = new Random();
				int oneCum;

				while (true)
				{
					oneCum = Ran.Next(0, AtomList.Count);
					DetalList[oneCum] += DETAL;

					double sums = Sums(AtomList, DetalList);
					if (sums > Expected)
					{
						if (sums - Expected < 0.01)
						{
							return DetalList;
						}
						break;
					}
					if (Expected - sums < 0.01)
					{
						return DetalList;
					}
				}
			}
		}

		private void InitDetal(int count)
		{
			DetalList.Clear();
			Random Ran = new Random();
			for (int i = 0; i < count; i++)
			{
				double delta = Ran.Next(0, 10) / 10;
				DetalList.Add(1 + delta);
			}
		}

		private double Sums(List<double> atom, List<double> detal)
		{
			double sum = 0.0;

			for (int i = 0; i < atom.Count; i++)
				sum += atom[i] * detal[i];

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