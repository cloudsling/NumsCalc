using System;
using System.Collections.Generic;

namespace NumCalc
{
    class Program
    {

        static int triedCount = 0;
        static void Main(string[] args)
        {
            double exption = 464808;
            double detal = 0.01;
            var atomList = new List<double>{
                   1190,1700,1390,1970,1390,970,1170
                };

            var data = UnitTest.Data();

            double utSum = Sums(atomList, data);

            if (utSum - exption <= 0.01)
            {
                Console.WriteLine("Success!");
            }

            while (true)
            {
                var detalList = new List<double>{
                   1,1,1,1,1,1,1
                };


                Random ran = new Random();

                while (true)
                {
                    int oneCum = GetRandom(ran);
                    detalList[oneCum] += detal;

                    double sums = Sums(atomList, detalList);
                    var sig = ResEqual(sums, exption);

                    switch (sig)
                    {
                        case SSignal.Overflow:
                            Console.WriteLine("Fault! " + ++triedCount);
                            break;
                        case SSignal.Suss:
                            Console.WriteLine(sums);
                            foreach (var item in detalList)
                                Console.WriteLine(item);
                            return;
                    }
                    // if (sums > exption)
                    // {
                    //     Console.WriteLine("Fault! " + ++triedCount);
                    //     break;
                    // }
                    // if (exption - sums < 0.01)
                    // {
                    //     Console.WriteLine(sums);

                    //     foreach (var item in detalList)
                    //         Console.WriteLine(item);

                    //     return;
                    // }
                    // else continue;
                }
            }
        }

        static SSignal ResEqual(double sums, double exption)
        {
            if (sums > exption)
            {
                Console.WriteLine("Fault! " + ++triedCount);
                return SSignal.Overflow;
            }
            else if (exption - sums < 0.01)
            {
                Console.WriteLine(sums);
                return SSignal.Suss;
            }
            else return SSignal.Overflow;
        }
        static double Sums(List<double> atom, List<double> detal)
        {
            double sum = 0.0;

            for (int i = 0; i < atom.Count; i++)
                sum += atom[i] * detal[i];

            return sum;
        }

        static int GetRandom(Random ran)
        {
            return ran.Next(0, 7);
        }

        private enum SSignal
        {
            Suss, Overflow
        }

    }
}
