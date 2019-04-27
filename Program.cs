using System;
using System.Collections.Generic;

namespace NumCalc
{
    class Program
    {

        static int triedCount = 0;
        static void Main(string[] args)
        {
            // double exption = 464808;
            double exption = 3982240;//755920;
            double detal = 0.01;

            var atomList = new List<double>{
                   11900,17000,13900,19700,13900
                };

            while (true)
            {
                var detalList = new List<double>{
                   1,1,1,1,1
                };

                Random ran = new Random();
                int oneCum;
                Console.WriteLine("Starting...");
                while (true)
                {
                    oneCum = GetRandom(ran);
                    detalList[oneCum] += detal;

                    double sums = Sums(atomList, detalList);
                    var sig = ResEqual(sums, exption);

                    // switch (sig)
                    // {
                    //     case SSignal.Overflow:
                    //         if (sums - exption < 100)
                    //         {
                    //             Console.WriteLine("Overflow" + sums);
                    //             Print(detalList);
                    //         }
                    //         Console.Write(".");
                    //         continue;
                    //     case SSignal.Suss:
                    //         Console.WriteLine(sums);
                    //         foreach (var item in detalList)
                    //             Console.WriteLine(item);
                    //         return;
                    //     case SSignal.Goon:
                    //         continue;
                    // Console.Write(".");
                    // }
                    if (sums > exption)
                    {
                        if (sums - exption < 0.01)
                        {
                            Console.WriteLine(sums);

                            foreach (var item in detalList)
                                Console.WriteLine(item);

                            Console.Read();
                        }
                        Console.WriteLine("Fault! " + ++triedCount);
                        break;
                    }
                    if (exption - sums < 0.01)
                    {
                        Console.WriteLine(sums);

                        foreach (var item in detalList)
                            Console.WriteLine(item);

                        Console.Read();
                    }

                    else continue;
                }
            }
        }

        static void Print(List<double> detalList)
        {
            for (int i = 0; i < detalList.Count; i++)
            {
                // Console.WriteLine(detalList[i]);
                detalList[i] = 1;
            }
        }

        static SSignal ResEqual(double sums, double exption)
        {
            if (sums > exption)
            {
                //Console.WriteLine("Fault! " + ++triedCount + sums.ToString());
                return SSignal.Overflow;
            }
            else if (exption - sums < 0.01)
            {
                Console.WriteLine(sums);
                return SSignal.Suss;
            }
            else return SSignal.Goon;
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
            return ran.Next(0, 5);
        }

        private enum SSignal
        {
            Suss, Goon, Overflow
        }

    }
}
