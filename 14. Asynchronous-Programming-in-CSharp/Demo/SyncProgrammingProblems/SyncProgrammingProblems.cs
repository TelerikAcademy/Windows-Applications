namespace SyncProgrammingProblems
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    // 10000000
    public static class SyncProgrammingProblems
    {
        public static void Main()
        {
            Console.WriteLine("Enter range first:");
            var rangeFirst = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter range last:");
            var rangeLast = int.Parse(Console.ReadLine());

            Console.WriteLine("Calculating primes... you can't do anything now");
            PrintPrimesInRange(rangeFirst, rangeLast);

            while (true)
            {
                Console.WriteLine("Here, write some text:");
                Console.ReadLine();
            }
        }

        private static List<int> PrimesInRange(int rangeFirst, int rangeLast)
        {
            var primes = new List<int>();

            for (int number = rangeFirst; number <= rangeLast; number++)
            {
                bool isPrime = true;
                for (int divider = 2; divider <= Math.Sqrt(number); divider++)
                {
                    if (number % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

        private static void PrintPrimesInRange(int rangeFirst, int rangeLast)
        {
            var stopwatch = Stopwatch.StartNew();
            var primesInRange = PrimesInRange(rangeFirst, rangeLast);
            Console.WriteLine(stopwatch.Elapsed);

            Console.WriteLine("Primes from {0} to {1} calculated. Print now (y/n)?", rangeFirst, rangeLast);
            var userAnswer = Console.ReadLine();
            
            if (userAnswer == "y" || userAnswer == "Y")
            {
                foreach (var prime in primesInRange)
                {
                    Console.WriteLine(prime);
                }
            }
        }
    }
}
