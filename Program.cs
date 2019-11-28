using System;
using System.Collections.Generic;

namespace NumCalc
{
  class Program
  {
    static void Main(string[] args)
    {
      //double exption = 464808;
      double exption = 10017639.14;//755920;

      var atomList = new List<double>{
                   11900,17000,13900,19700,13900
                };

      Test(atomList);

      var calc = new Calculator(exption, atomList);

      Console.WriteLine("Starting...");
      var calced = calc.Calculcate();

      if (calced != null)
      {
        foreach (var item in calced)
          Console.WriteLine(item);

        Console.Read();
      }
    }

    public static void Test(List<double> atomList)
    {
      var UTdate = UnitTest.Data();
      double sums = 0.0;
      for (int i = 0; i < UTdate.Count; i++)
      {
        sums += UTdate[i] * atomList[i];
      }
      Console.WriteLine();
    }
  }
}
