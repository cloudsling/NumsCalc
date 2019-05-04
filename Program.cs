using System;
using System.Collections.Generic;

namespace NumCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //double exption = 464808;
            double exption = 3982240;//755920;

            var atomList = new List<double>{
                   11900,17000,13900,19700,13900
                };

            var calc = new Calculator(exption, atomList);
            var calced = calc.Calculcate();

            if (calced != null)
            {
                foreach (var item in calced)
                    Console.WriteLine(item);

                Console.Read();
            }
        }
    }
}
