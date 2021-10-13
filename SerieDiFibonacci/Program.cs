using System;

namespace SerieDiFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            //con iterazione
            int fibonacciIterazione = FibonacciIterazione(n);
            Console.WriteLine(fibonacciIterazione);

            int fibonacciRicorsione = FibonacciRicorsione(n);
            Console.WriteLine(fibonacciRicorsione);

        }

        private static int FibonacciIterazione(int n)
        {
            int[] serieDiFibonacci = new int[n];
            serieDiFibonacci[0] = 1;
            serieDiFibonacci[1] = 1;

            for (int i = 2; i < serieDiFibonacci.Length; i++)
            {
                serieDiFibonacci[i] = serieDiFibonacci[i - 1] + serieDiFibonacci[i - 2];
            }
            int elementoFibonacci = serieDiFibonacci[n - 1];
            return elementoFibonacci;
        }

        private static int FibonacciRicorsione(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            else
            {
                return FibonacciRicorsione(n - 1) + FibonacciRicorsione(n - 2);

            }

        }
    }
}
