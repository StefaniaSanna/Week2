using System;

namespace CarteDiCredito
{
    // Le carte di pagamento sono lunghe 16 cifre.
    // Le prime 6 cifre rappresentano un numero di identificazione univoco per la banca che ha emesso la carta.
    // Le successive 2 cifre determinano il tipo di carta (ad es. debito, credito, regalo).
    // Le cifre da 9 a 15 sono il numero di serie della carta
    // L'ultima cifra è utilizzata come cifra di controllo per verificare se il numero della carta è valido.

    // Hans Peter ha inventato un metodo per determinare se un numero di carta di credito è sintatticamente valido

    // Step 1 : Vengono raddoppiate le cifre che si trovano in posizione dispari e
    // Step 2 : Se questo "raddoppio" risulta in un numero a due cifre, viene sottratto 9 da esso per ottenere una sola cifra.
    // Step 3 : Vengono sommante tutte le cifre ottenute
    // Step 4 : Vengono aggiunte le cifre nelle posizioni pari
    // Step 5 : Se il risultato è divisibile per 10, il numero della carta è valido; in caso contrario, non è valido.

    // Esempi
    // Carta di pagamento : 4 5 5 6 7 3 7 5 8 6 8 9 9 8 5 5
    // Step 1 : 8 5 10 6 14 3 14 5 16 6 16 9 18 8 10 5
    // Step 2 : 8 5 1 6 5 3 5 5 7 6 7 9 9 8 1 5
    // Step 3 : 8 + 1 + 5 + 5 + 7 + 7 + 9 + 1 = 43
    // Step 4 : 43 + (5+6+3+5+6+9+8+5) = 43 + 47 = 90
    // Step 5 : 90/10 = 9 resto 0 -> Numero della carta valido

    // Esempi
    // Carta di pagamento : 4 0 2 4 0 0 7 1 0 9 0 2 2 1 4 3
    // Step 1 : 8 0 4 4 0 0 14 1 0 9 0 2 4 1 8 3
    // Step 2 : 8 0 4 4 0 0 5 1 0 9 0 2 4 1 8 3
    // Step 3 : 8 + 4 + 0 + 5 + 0 + 0 + 4 + 8 = 29
    // Step 4 : 29 + (0+4+0+1+9+2+1+3) = 29 + 20 = 49
    // Step 5 : 49/10 = 4 resto 9 -> Numero della carta non valido
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserire il numero della carta di credito");
            int[] numeroCarta = InserireNumeroCarta();
            int[] cifrePari = new int[8];
            int[] cifreDispari = new int[8];
            ControlloNumeriCarta(numeroCarta, ref cifrePari, ref cifreDispari);
            int[] cifreDispariRaddoppiate = RaddoppioValore(cifreDispari);
            int[] cifreDispariCorrette = VerificaNumeroCifre(cifreDispariRaddoppiate);
            int SommaElementiDispari = SommaElementi(cifreDispariCorrette);
            int SommaElementiPari = SommaElementi(cifrePari);
            Verdetto(SommaElementiPari, SommaElementiDispari);


        }


        //Metodo per inserire il numero di carta
        private static int[] InserireNumeroCarta()
        {
            int lunghezzaCodice = 16;
            int[] numeroCarta = new int[16];
            for (int i = 0; i < lunghezzaCodice; i++)
            {
                int numeroProvvisorio = 0;
                do
                {
                    Console.WriteLine($"Inserire il {i + 1} numero della carta");

                } while (!int.TryParse(Console.ReadLine(), out numeroProvvisorio));
                numeroCarta[i] = numeroProvvisorio;
            }
            return numeroCarta;
        }

        private static void ControlloNumeriCarta(int[] numeroCarta, ref int[] cifrePari, ref int[] cifreDispari)
        {
            //Divido in cifre pari e dispari
            cifrePari = new int[8];
            cifreDispari = new int[8];
            int contatorePari = 0;
            int contatoreDispari = 0;

            for (int i = 0; i < numeroCarta.Length; i++)
            {
                if (i % 2 == 0) //è dispari
                {
                    cifreDispari[contatoreDispari] = numeroCarta[i];
                    contatoreDispari++;
                }
                else
                {
                    cifrePari[contatorePari] = numeroCarta[i];
                    contatorePari++;
                }
            }
        }

        // MetodoRaddoppio
        private static int[] RaddoppioValore(int[] cifre)
        {
            int[] cifreRaddoppiate = new int[8];
            for (int i = 0; i < cifreRaddoppiate.Length; i++)
            {
                cifreRaddoppiate[i] = 2 * cifre[i];
            }
            return cifreRaddoppiate;
        }

        //Metodo togli 9
        private static int[] VerificaNumeroCifre(int[] cifre)
        {
            int[] valoriCorretti = new int[8];
            for (int i = 0; i < cifre.Length; i++)
            {
                if (cifre[i] >= 10)
                {
                    valoriCorretti[i] = cifre[i] - 9;

                }
                else
                {
                    valoriCorretti[i] = cifre[i];
                }
            }
            return valoriCorretti;
        }
        //metodo della somma di tutti gli elementi
        private static int SommaElementi(int[] array)
        {
            int somma = 0;
            for (int i = 0; i < array.Length; i++)
            {
                somma += array[i];
            }
            return somma;
        }
        private static void Verdetto(int pari, int dispari)
        {
            int somma = pari + dispari;
            if (somma % 10 == 0)
            {
                Console.WriteLine("La carda è valida");
            }
            else
            {
                Console.WriteLine("La carta non è valida");
            }
        }
    }
}
