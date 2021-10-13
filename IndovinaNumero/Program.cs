using System;
using System.IO;

namespace IndovinaNumero
{//Esercizio: Indovina Numero.
 //Il gioco consiste nell’indovinare un numero tra 1 e 100, generato in modo casuale.


    //L’utente accede e visualizza un messaggio di benvenuto.
    //Gli viene chiesto di inserire il suo nome, quindi, una volta inserito,
    //compare un messaggio del tipo “Ciao NOME!” ed un menu con delle scelte/opzioni.
    //In particolare potrà scegliere se iniziare a giocare una partita o uscire dal programma.


    //Se l’utente decide di uscire, verrà visualizzato un messaggio di arrivederci.


    //Se invece decide di giocare dovrà essere generato un numero casuale
    //che ovviamente NON dovrà essere mostrato a video.
    //(Opzionale: il numero può essere salvato in un file “NumeroDaIndovinare.txt”).

    //Dopo la generazione e memorizzazione del numero casuale,
    //si dovrà chiedere all’utente di provare ad indovinare il numero
    //specificando a video(e quindi controllando in fase di inserimento)
    //che si tratta di un numero compreso tra 1 e 100.
    //(Opzionale: Se l’utente inserisce “0” interrompe la partita e
    //gli verrà mostrato un messaggio di “Partita interrotta” quindi
    //svelato il numero che doveva indovinare.Ritornerà quindi al menu iniziale.)

    //Bisognerà tener traccia dei tentativi che fa,
    //mostrando il numero dei tentativi che sono stati fatti.

    //--------------------------------------------------------------------
    //Esempio:
    //Finora hai effettuato 0 tentativi.
    //Inserisci il tuo 1° tentativo(0 per interrompere la partita) :
    //--------------------------------------------------------------------

    //L’utente dovrà provare quindi ad indovinare il numero.
    //Ogni volta che l’utente prova ad inserire un numero, cioè inserisce un tentativo,
    //bisognerà quindi verificare se il numero inserito corrisponde al numero segreto.
    //Se l’utente NON indovina il numero, gli verrà mostrato un suggerimento del tipo
    //“Prova con un numero più alto” o “Prova con un numero più basso”
    //in base al confronto tra il numero che l’utente ha inserito e il numero segreto.
    //Quindi l’utente farà un altro tentativo e così via finché indovina il numero!

    //---------------------------------------------------------------------------------------
    //Esempio (Il numero da indovinare è 20 e l'utente inserisce come secondo tentativo 15):

    //Suggerimento: Inserisci un numero più alto.
    //Finora hai effettuato 2 tentativi.
    //Inserisci il tuo 3° tentativo (0 per interrompere la partita):
    //---------------------------------------------------------------------------------------

    //Se/quando l’utente indovina il numero, verrà visualizzato il messaggio:
    //“Complimenti hai vinto! Ti sono bastati X tentativi! Bravo!”.
    //E verrà rimandato al menu iniziale.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");
            Console.WriteLine("Inserire il proprio nome:");
            string nome = Console.ReadLine();
            Console.WriteLine($"Ciao {nome}!");
            int scelta = 0;
            int numerocasuale = 0;
            int ipotesiUtente = 0;
            int contTentativi = 0;
            bool continua = true;

            while (continua)
            {
                IniziaEEstrazione(nome, ref continua, ref scelta, ref numerocasuale);
                if (continua == false)
                {
                    break;
                }
                //do
                //{
                //    Console.WriteLine("********Menu********");
                //    Console.WriteLine("[1] Inizia a giocare");
                //    Console.WriteLine("[2] Esci");
                //}
                //while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta > 0 && scelta <= 2));

                //if (scelta == 2)
                //{
                //    Console.WriteLine($"Arrivederci {nome}");
                //    continua = false;
                //    break;

                //}
                //else
                //{
                //    Random random = new Random();
                //    numerocasuale = random.Next(1, 101);
                //    //Console.WriteLine(numerocasuale); //per provare
                //}

                string path = @"C:\Users\sanna\Desktop\Programmi Pink\Week2\IndovinaNumero\NumeroSegreto.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"Il numero segreto è {numerocasuale}");
                }

                do
                {
                    do
                    {
                        Console.WriteLine("L'utente deve selezionare un numero compreso tra 1 e 100.");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out ipotesiUtente) && ipotesiUtente <= 100));
                    contTentativi++;

                    if (ipotesiUtente == numerocasuale)
                    {
                        Console.WriteLine($"Hai vinto! Ti sono bastati {contTentativi} tentativi.");
                    }
                    else
                    {
                        if (ipotesiUtente < numerocasuale && ipotesiUtente != 0)
                        {
                            Console.WriteLine("Suggerimento: inserisci un numero più alto.");
                            Console.WriteLine($"Finora hai effettuato {contTentativi} tentativi.");
                            Console.WriteLine($"INserisci il tuo {contTentativi + 1}° tentativo. 0 per uscire.");
                        }
                        else if (ipotesiUtente == 0)
                        {
                            Console.WriteLine($"Partita interrotta. Il numero segreto era {numerocasuale}.");
                            continua = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Suggerimento: inserisci un numero più basso.");
                            Console.WriteLine($"Finora hai effettuato {contTentativi} tentativi.");
                            Console.WriteLine($"INserisci il tuo {contTentativi + 1}° tentativo. 0 per uscire.");
                        }


                    }

                }
                while (numerocasuale != ipotesiUtente);
            }
        }
        //Metodo per iniziare e estrarre il numero casuale
        private static void IniziaEEstrazione(string nome, ref bool continua, ref int scelta, ref int numerocasuale)
        {
            do
            {
                Console.WriteLine("********Menu********");
                Console.WriteLine("[1] Inizia a giocare");
                Console.WriteLine("[2] Esci");
            }
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta > 0 && scelta <= 2));

            if (scelta == 2)
            {
                Console.WriteLine($"Arrivederci {nome}");
                continua = false;
            }
            else
            {
                Random random = new Random();
                numerocasuale = random.Next(1, 101);
                //Console.WriteLine(numerocasuale); 
            }
        }
    }
}
