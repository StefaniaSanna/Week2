using System;
using System.IO;

namespace ScritturaLetturaFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\sanna\Desktop\Programmi Pink\Week2\ScritturaLetturaDaFile\fileProva.txt";
            //scrittura su file con chiusura manuale
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("Ciao");
            sw.Close();

            //scrittura su file con chiusura automatica

            //scrittura su file sovrascriventìdo le cose precedenti
            using (StreamWriter sw1 = new StreamWriter(path))
            {
                sw1.WriteLine("Buongiorno"); //usando using non devo fare close
            }

            //scrittura su file mantenendo il contenuto precedente

            using (StreamWriter sw1 = new StreamWriter(path, true))
            {
                sw1.WriteLine("Come state?");

            }
            //lettura di tutti i file
            using (StreamReader sr1 = new StreamReader(path))
            {
                string contenutoFile = sr1.ReadToEnd();
            }
            //lettura di una riga dal  file
            using (StreamReader sr1 = new StreamReader(path))
            {
                string contenutoRiga = sr1.ReadLine();
            }

            //lettura di tutto il file e divisione del file in righe

            using (StreamReader sr1 = new StreamReader(path))
            {
                string contenutoFile = sr1.ReadToEnd();
                var arrayDiRIghe = contenutoFile.Split("\r\n");
            }





        }
    }
}
