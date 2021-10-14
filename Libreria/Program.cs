using System;
using System.Collections.Generic;

namespace Libreria
{
    /*
Scrivere un programma che gestisca una libreria.
Un libro è un'entità che ha
Codice
Titolo
Autore
Genere
Prezzo
Data pubblicazione
Per il genere usare un enum
Sarà possibile inserire un nuovo libro, eliminare un libro, modificare un libro o cercare i libri per genere
*/
    class Program
    {
        static void Main(string[] args)
        {

            Menù.Start();
            
            //Libro libro1 = new Libro(); //costruisci una variabile di nome libro e tipo Libro che avrà delle proprietà
            ////Questo è il costruttore vuote, prepara un pezzo di memoria per memorizzare il libro
            //libro1.Codice = "cod001"; //con il punto accedo alle proprietà di libro, e gli ho assegnato il suo codice
            //libro1.Autore = "Manzoni";
            //libro1.Titolo = "I promessi sposi";
            //libro1.Prezzo = 12;
            //libro1.DataPubblicazione = new DateTime(2020,10,21);

            //Console.WriteLine($"{libro1.Autore}");

            ////creo un secondo libro

            //Libro libro2 = new Libro();
            //libro2.Codice = "cod002"; 
            //libro2.Autore = "Dante";
            //libro2.Titolo = "La divina commedia";

            ////sto creando tanti oggetti diversi reali

            ////evoluzione dell'array è la lista

            //List < Libro > libri = new List<Libro>();
            //// sto creando una lista che può contere libri, solo libri. Non si deve dare la dimensione quindi è dinamica
            ////posso aggiungere o tagliere elementi
            //libri.Add(libro1); // ora la lista contiene libro 1
            ////posso chiedere quanti elementi ha
            //Console.WriteLine($"La mia lista contiene {libri.Count} libri");
            //libri.Add(libro2);
            //Console.WriteLine($"La mia lista contiene {libri.Count} libri");
            //libri.Remove(libro1);
            //Console.WriteLine($"La mia lista contiene {libri.Count} libri"); // con questo posso togliere elementi


        }
    }
}
