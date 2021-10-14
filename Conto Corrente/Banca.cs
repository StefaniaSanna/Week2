using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente
{
    public  class Banca
    {
        public static void Start()
        {
            BancaManager.AggiungiContoProva();
            Console.WriteLine("Benvenuto nella nostra Banca");
            bool continua = true;

            do
            {
                Console.WriteLine("********Menù********");
                Console.WriteLine("Premi 1 per creare un conto");
                Console.WriteLine("Premi 2 per cancellare un conto");
                Console.WriteLine("Premi 3 per modificare i dati di un conto");
                Console.WriteLine("Se sei un membro della banca premi 4 per visionare tutti i conti attivi");
                Console.WriteLine("Premi 0 per uscire");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1: 
                        BancaManager.AggiungiConto();
                        break;
                    case 2:
                        BancaManager.EliminaConto();
                        break;
                    case 3:
                        BancaManager.ModificaConto();
                        break;
                    case 4:
                        BancaManager.StampaConti();
                        break;
                    case 0: 
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        break;
                }

            }
            while (continua == true);
            

        }
    }
}
