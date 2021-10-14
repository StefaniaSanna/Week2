using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public static class LibreriaManager
    {


        public static List<Libro> libri = new List<Libro>();

        //se voglio aggiungere dei libri per fare delle prove

        public static void AggiungiDatiProva()
        {
            Libro libro1 = new Libro() { Codice = "c001", Titolo = "Promessi sposi", Autore = "Manzoni", Genere = (Genere)1, Prezzo = 10, DataPubblicazione = new DateTime(2010, 10, 12)};
            libri.Add(libro1);
        }
        
        //case 1
        public static void AggiungiLibro()
        {
            //chiedo all'utente le informazioni necessarie per aggiungere il libro
            Libro libro= new Libro();  // genero un libro vuoto
            Console.WriteLine("Inserisci il codice del libro");
            libro.Codice = Console.ReadLine();
            Console.WriteLine("Inserisci il titolo del libro");
            libro.Titolo = Console.ReadLine();
            Console.WriteLine("Inserisci l'autore del libro");
            libro.Autore = Console.ReadLine();
            libro.Prezzo = InserisciPrezzo();
            libro.DataPubblicazione = InserisciDataPubblicazione();
            libro.Genere = InserisciGenere();

            libri.Add(libro);
            Console.WriteLine("Libro aggiunto correttamente");


        }

        private static Genere InserisciGenere()
        {
            Console.WriteLine("Inserisci il genere del libro");
            Console.WriteLine($"Premi {(int)Genere.Narrativa} per il genere {Genere.Narrativa}");
            Console.WriteLine($"Premi {(int)Genere.Storico} per il genere {Genere.Storico}");
            Console.WriteLine($"Premi {(int)Genere.Fantasy} per il genere {Genere.Fantasy}");

            int genere;
            do
            {
                Console.WriteLine("Fai la tua scelta");
            }
            while (!(int.TryParse(Console.ReadLine(), out genere) && genere>= 1 && genere <= 3 ));

            return (Genere)genere;
        }

        private static DateTime InserisciDataPubblicazione()
        {
            DateTime data;
            do
            {
                Console.WriteLine("Inserisci la data di pubblicazione del libro");

            }
            while (!(DateTime.TryParse(Console.ReadLine(), out data) && data <= DateTime.Today));

            return data;
        }

        private static double InserisciPrezzo()
        {
            double prezzo;
            do
            {
                Console.WriteLine("Inserisci il prezzo del libro");

            }
            while (!(double.TryParse(Console.ReadLine(), out prezzo) && prezzo > 0));

            return prezzo;
        }

        //case2
        public static void EliminaLibro()
        {
            Console.WriteLine("I libri presenti nella libreria sono:");
            StampaLibri();
            Console.WriteLine("Digita il codice del libro che vuoi eliminare");
            string codiceInseritoDaUtente = Console.ReadLine();
            Libro libroTrovato= CercaLibro(codiceInseritoDaUtente);
            if (libroTrovato == null)
            {
                Console.WriteLine("Libro non trovato, codice errato");
            }
            else
            {
                libri.Remove(libroTrovato);
                Console.WriteLine("Libro eliminato correttamente");
            }

        }

        private static Libro CercaLibro(string codice)
        {
            foreach (Libro libro in libri)
            {
                if (codice == libro.Codice)
                {
                    return libro;
                }               
            }
            return null;
        }






        public static void ModificaLibro()
        {
            Console.WriteLine("I libri presenti nella lista sono:");
            StampaLibri();
            Console.WriteLine("Inserisci il codice del libro che vuoi modificare");
            string codice = Console.ReadLine();
            Libro libroDaModificare = CercaLibro(codice);
            if (libroDaModificare == null)
            {
                Console.WriteLine("Libro non trovato");
            }
            else
            {
                bool continua = true;
                do
                {
                    Console.WriteLine(" Premi 1 per modificare il titolo");
                    Console.WriteLine(" Premi 2 per modificare l'autore");
                    Console.WriteLine(" Premi 3 per modificare il genere");
                    Console.WriteLine(" Premi 4 per modificare il prezzo");
                    Console.WriteLine(" Premi 5 per modificare la data di pubblicazione");
                    Console.WriteLine(" Premi 0 per concludere la modifica");

                    int scelta;
                    
                    do
                    {
                        Console.WriteLine("Fai la tua scelta");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5));

                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("Inserire il nuovo titolo");
                            libroDaModificare.Titolo = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Inserire il nuovo autore");
                            libroDaModificare.Autore = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Inserire il nuovo genere");
                            libroDaModificare.Genere = InserisciGenere();
                            break;
                        case 4:

                            libroDaModificare.Prezzo = InserisciPrezzo();
                            break;
                        case 5:
                            libroDaModificare.DataPubblicazione = InserisciDataPubblicazione();
                            break;
                        case 0:
                            continua = false;
                            break;
                    }                  
                }
                while (continua);
            }           
        }
        public static void StampaLibriDiUnaLista(List<Libro> listaLibri)
        { 
            if (listaLibri.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Codice\t\tTitolo\t\tAutore\t\tGenere\t\tPrezzo\t\tData di Pubblicazione");
                foreach (Libro libro in listaLibri)
                {
                    Console.WriteLine($"{libro.Codice}\t\t{libro.Titolo}\t\t{libro.Autore}\t\t{libro.Genere}\t\t{libro.Prezzo}\t\t{libro.DataPubblicazione.ToShortDateString()}");

                }
            }

        }
        
        public static void StampaLibri()
        {
            StampaLibriDiUnaLista(libri);
        }




        public static void FiltraLibriPerGenere()
        {
            Genere g = InserisciGenere();
            List<Libro> libriFiltrati = new List<Libro>(); //lista vuota di libri
            foreach (Libro libro in libri)
            {
                if (libro.Genere == g)
                {
                    libriFiltrati.Add(libro);
                }
            }
            StampaLibriDiUnaLista(libriFiltrati);
        }
    }
}
