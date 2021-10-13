using System;

namespace Fattoriale
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int fattorialeIterazione = FattorialeIterativo(n);
            Console.WriteLine($"Il fattoriale {n}! calcolato con iterazione è {fattorialeIterazione}");

            int fattorialeRicorsione = FattorialeRicorsione(n);
            Console.WriteLine($"Il fattoriale {n}! calcolato con ricorsione è {fattorialeRicorsione}");

        }
        private static int FattorialeIterativo(int n)
        {
            int fattoriale = 1;
            for (int i = 1; i <= n; i++)
            {
                fattoriale *= i;
            }
            return fattoriale;
        }

        private static int FattorialeRicorsione(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return FattorialeRicorsione(n - 1) * n;
            }
        }
    }
}
