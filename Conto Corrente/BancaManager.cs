using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente
{
    public static class BancaManager
    {
        public static List<Conto> conti = new List<Conto>();

        // ci metto già un conto di prova

        public static void AggiungiContoProva()
        {
            Conto contoProva = new Conto()
            {
                Intestatario = "Mario Rossi",
                TipoConto = (TipoConto)1,               
                Saldo = 10000,
                NumeroConto = 12345,                
            };

            conti.Add(contoProva);
        }



        internal static void AggiungiConto()
        {
            Conto nuovoConto = new Conto();
            Console.WriteLine("Inserire il nome dell'intestatario");
            nuovoConto.Intestatario = Console.ReadLine();
            nuovoConto.TipoConto = SelezionaTipoConto();
            nuovoConto.Saldo = RiportaSaldo();
            nuovoConto.NumeroConto = RiportaNumeroConto();
            conti.Add(nuovoConto);
            Console.WriteLine($"Al momento in questa banca sono operativi {conti.Count} conti.");



        }

        private static int RiportaNumeroConto()
        {
            int numeroConto;
            do
            {
                Console.WriteLine("Scrivere il numero del conto");
            } while (!(int.TryParse(Console.ReadLine(), out numeroConto) && numeroConto >= 0));
            return numeroConto;
        }      

        private static double RiportaSaldo()
        {
            double saldo;
            do
            {
                Console.WriteLine("Scrivere il saldo");
            } while (!(double.TryParse(Console.ReadLine(), out saldo) && saldo >= 0 ));
            return saldo;

        }

        private static TipoConto SelezionaTipoConto()
        {
            Console.WriteLine("Selezionare la tipologia di conto che si desidera aprire");
            Console.WriteLine("Premere 1 per conto corrente");
            Console.WriteLine("Premere 2 per conto risparmio");

            int tipoConto;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            } while (!(int.TryParse(Console.ReadLine(), out tipoConto) && tipoConto >= 1 && tipoConto <= 2));
            return (TipoConto)tipoConto;
        }

        public static void EliminaConto()
        {
           Conto contoDaEliminare = VerificaNumeroConto();
           conti.Remove(contoDaEliminare);
            Console.WriteLine($"Al momento in questa banca sono operativi {conti.Count} conti.");


        }

        private static Conto VerificaNumeroConto()
        {
            int numeroConto;
            
            do
            {
                Console.WriteLine("Inserire il numero del conto che si vuole modificare");

            }
            while(!(int.TryParse(Console.ReadLine(), out numeroConto) && numeroConto >0));
            Conto contoIdentificato = CercaConto(numeroConto);
            return contoIdentificato;
            
           // Console.WriteLine($"Al momento in questa banca sono operativi {conti.Count} conti.");

        }

        private static Conto CercaConto(int nConto)
        {
            foreach  (Conto conto in conti)
            {
                if (nConto == conto.NumeroConto)
                {
                    return conto;
                }
            }
            return null;
        }

        public static void ModificaConto()
        {
            Conto contoDaModificare = VerificaNumeroConto();
            bool continua = true;
            do
            {
                Console.WriteLine("Premere 1 per modificare L'intestatario");
                Console.WriteLine("Premere 2 per modificare il tipo di conto");
                Console.WriteLine("Premere 3 per modificare il saldo");
                Console.WriteLine("Premere 4 per modificare numero del conto");
                Console.WriteLine("Premere 0 quando sono terminate le modifiche");
                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta");
                } while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));
                switch (scelta)
                {
                    case 1:
                        Console.WriteLine("Inserire il nuovo intestatario");
                        contoDaModificare.Intestatario = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Selezionare il nuovo tipo di conto");
                        contoDaModificare.TipoConto =SelezionaTipoConto();
                        break;
                    case 3:
                        Console.WriteLine("Selezionare il nuovo saldo");
                        contoDaModificare.Saldo = RiportaSaldo();
                        break;
                    case 4:
                        Console.WriteLine("Selezionare il nuovo numero del conto");
                        contoDaModificare.NumeroConto = RiportaNumeroConto();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        break;
                }

            }
            while (continua==true);


            
        }
        public static void StampaContiBanca(List<Conto> listaConti)
        {
            if (listaConti.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Intestatario - Tipo di conto - Saldo - Numero di conto");
                foreach (Conto conto  in listaConti)
                {
                    Console.WriteLine($" {conto.Intestatario} - {conto.TipoConto} - {conto.Saldo} - {conto.NumeroConto}");
                }
            }
        }

        public static void StampaConti()
        {
            StampaContiBanca(conti);

        }
    }
}
