using System;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Questa è una Calcolatrice!");
            Console.WriteLine("Come ti chiami?");
            string nomeUtente;
            nomeUtente = Console.ReadLine();
            Console.WriteLine($"Ciao {nomeUtente}");
            //Console.Write("Inserisci il primo numero intero:");
            bool continua = false;
            do
            {
                int primoNumero;


                do
                {
                    Console.WriteLine("Inserisci il primo numero intero:");

                } while (!int.TryParse(Console.ReadLine(), out primoNumero));
                Console.WriteLine($"Il primo numero che hai inserito è: {primoNumero}");

                int secondoNumero;
                do
                {
                    Console.WriteLine("Inserisci il secondo numero intero:");

                } while (!int.TryParse(Console.ReadLine(), out secondoNumero));
                Console.WriteLine($"Il secondo numero che hai inserito è: {secondoNumero}");


                Console.WriteLine("\n--------------------Menu----------------------\n");
                Console.WriteLine("Scegli A per fare la somma dei 2 numeri inseriti");
                Console.WriteLine("Scegli B per fare la differenza dei 2 numeri inseriti");
                Console.WriteLine("Scegli C per fare il prodotto dei 2 numeri inseriti");
                Console.WriteLine("Scegli D per fare il quoziente dei 2 numeri inseriti");

                char sceltaUtente;

                do
                {
                    Console.WriteLine("\nFai la tua scelta");
                    sceltaUtente = Console.ReadKey().KeyChar;

                } while (!(sceltaUtente.ToString().ToUpper() == "A" || sceltaUtente.ToString().ToUpper() == "B" || sceltaUtente.ToString().ToUpper() == "C" || sceltaUtente.ToString().ToUpper() == "D")); //case sensitive

                Console.WriteLine($"la tua scelta è {sceltaUtente}");
                switch (sceltaUtente.ToString().ToUpper())
                {
                    case "A":
                        //int somma;
                        //somma = primoNumero + secondoNumero;
                        int somma = Sum(primoNumero, secondoNumero);
                        Console.WriteLine($"La somma è: {somma}");
                        break;
                    case "B":
                        //int differenza;
                        //differenza = primoNumero - secondoNumero;
                        int differenza = Subtract(primoNumero, secondoNumero);
                        Console.WriteLine($"La differenza è: {differenza}");
                        break;

                    case "C":
                        //int prodotto;
                        //prodotto = primoNumero * secondoNumero;
                        int prodotto = Multiply(primoNumero, secondoNumero);
                        Console.WriteLine($"Il prodotto è : {prodotto}");
                        break;

                    case "D":
                        if (secondoNumero == 0)
                        {
                            Console.WriteLine("Impossibile");
                        }
                        else
                        {
                            //double quoziente;
                            //quoziente = (double)primoNumero / secondoNumero;
                            double quoziente = Divide(primoNumero, secondoNumero);
                            Console.WriteLine($"Il quoziente è {quoziente}");
                        }
                        break;
                }

                Console.WriteLine("Vuoi continuare? Inserisi si per continuare, qualsiasi altra cosa per uscire");
                string risposta = Console.ReadLine();

                if (risposta.ToLower() == "si")
                {
                    continua = true;
                }
                else
                {
                    continua = false;
                }

            } while (continua);
        }

        //Metodi per le operazioni
        //Metodo somma
        private static int Sum(int x, int y)
        {
            return x + y;
        }

        //Metodo sottrazione
        private static int Subtract(int x, int y)
        {
            return x - y;
        }

        // Metodo divisione
        private static double Divide(int x, int y)
        {
            return (double)x / y;
        }

        //Metodo moltiplicazione
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
    
}
