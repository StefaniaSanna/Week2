using System;

namespace BollettaLuce
/* Realizzare un’applicazione console che consenta di eseguire il calcolo della bolletta della luce.
Si richiede di sviluppare un menù attraverso cui l’utente può scegliere di:

inserire i propri dati (nome, cognome e kwH consumati);
richiedere il calcolo del costo della bolletta che è costituito da una quota fissa di 40€ più il prodotto tra i kwH e 10.
stampare a video i valori della bolletta, inclusi nome, cognome e costo pagato.
Ciascuna delle operazioni descritte sopra dovrà essere implementata attraverso una opportuna routine.*/
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Benvenuto nell'applicazione per calcolare la bolletta della luce");
            bool continua;
            string nome = "";
            string cognome = "";
            double chilowatt = 0.0;
            double bolletta = 0.0;
            do
            {
                Console.WriteLine($"********Menù********");
                Console.WriteLine("[1] Inserire nome, cognome e kWh consumati.");
                Console.WriteLine("[2] Calcolo del costo della bolletta della luce.");
                Console.WriteLine("[3] Stampare credenziali e valore della bolletta.");
                int choice;
                do
                {
                    Console.WriteLine("Inserire la scelta");

                } while (!int.TryParse(Console.ReadLine(), out choice));
                switch (choice)
                {
                    case 1:

                        InserireCredenziali(ref nome, ref cognome, ref chilowatt);
                        break;
                    case 2:

                        bolletta = CalcoloBolletta(chilowatt);

                        break;
                    case 3:
                        StampaInformazioni(nome, cognome, chilowatt, bolletta);
                        break;
                }
                Console.WriteLine("Vuoi accedere ad altre funzioni del Menù? Inserisci si per continuare, qualsiasi altra cosa per uscire");
                string risposta = Console.ReadLine();

                if (risposta.ToLower() == "si")
                {
                    continua = true;
                }
                else
                {
                    continua = false;
                }

            }
            while (continua);
        }

        // creiamo una procedura con ref, cioè non mi restituisce nulla ma siccome è ref me le modifica anche fuori
        private static void InserireCredenziali(ref string nome, ref string cognome, ref double chilowatt)
        {
            Console.WriteLine("Inserire il nome");
            nome = Console.ReadLine();
            Console.WriteLine("Inserire il cognome");
            cognome = Console.ReadLine();
            chilowatt = 0.0;

            do
            {
                Console.WriteLine("Inserire i kwh consumati");

            } while (!double.TryParse(Console.ReadLine(), out chilowatt));
        }
        private static double CalcoloBolletta(double chilowatt)
        {
            double Bolletta = 40 + chilowatt * 10;
            return Bolletta;
        }
        private static void StampaInformazioni(string nome, string cognome, double chilowatt, double bolletta)
        {

            Console.WriteLine($"Nome: {nome}, Cognome: {cognome}, kWh consumati: {chilowatt}, bolletta: {bolletta} euro");
        }
    }
}
