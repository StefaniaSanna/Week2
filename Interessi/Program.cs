using System;

namespace Interessi
{
    // Scrivere una funzione che dato un importo di denaro iniziale,
    // un interesse annuo e un numero di anni permette di calcolare
    // l’importo di denaro accresciuto degli interessi dopo il numero di anni passati

    // Esempio
    // Voglio vincolare 10000 euro per 3 anni con un interesse del 3%

    // Dopo 1 anno : 10000 + (10000 * 3 / 100) = 10000 + 300 = 10300
    // Dopo 2 anni : 10300 + (10300 * 3 / 100) = 10300 + 309 = 10609
    // Dopo 3 anni : 10609 + (10609 * 3 / 100) = 10609 + 318,27 = 10927,27
    class Program
    {
        static void Main(string[] args)
        {
            double soldiinvestiti = 10000.0;
            int anni = 3;
            double interesse = 3.0;
            double soldiaumentati = CalcolareSoldiIterazione(soldiinvestiti, anni, interesse);
            Console.WriteLine(soldiaumentati);

            double soldiaumentatiRicorsione = CalcolareSoldiRicorsione(soldiinvestiti, anni, interesse);
            Console.WriteLine(soldiaumentatiRicorsione);

        }
        //metodo iterativo
        private static double CalcolareSoldiIterazione(double soldiinvestiti, int anni, double interesse)
        {
            double[] arraySoldi = new double[anni];
            arraySoldi[0] = soldiinvestiti + soldiinvestiti * 3 / 100;

            for (int i = 1; i < anni; i++)
            {
                arraySoldi[i] = arraySoldi[i - 1] + arraySoldi[i - 1] * 3 / 100;
            }
            return arraySoldi[anni - 1];
        }
        private static double CalcolareSoldiRicorsione(double soldiinvestiti, int anni, double interesse)
        {
            if (anni == 1)
            {
                return soldiinvestiti + soldiinvestiti * 3 / 100;
            }

            else
            {
                return CalcolareSoldiRicorsione(soldiinvestiti, anni - 1, interesse) + CalcolareSoldiRicorsione(soldiinvestiti, anni - 1, interesse) * 3 / 100;
            }
        }


    }
}
