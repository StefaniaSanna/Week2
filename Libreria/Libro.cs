using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Libro
    {
        //elenco proprietà
        public string Codice { get; set; } // scrivi prop e doppio tab
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public Genere Genere { get; set; } // proprietà di nome genere del tipo genere che abbiamo definito fuori
        //definisco genere come enum
        public double Prezzo { get; set; }
        public DateTime DataPubblicazione { get; set; }

        //Costruttore:metodo speciale che serve per costruire oggetti libro
        //è un metodo che non prende nuente e non ha niente, è un metodo
        //scrivi ctor e doppio tab
        public Libro()
        {

        }

    }
    public enum Genere
    {
        Narrativa=1,
        Storico=2,
        Fantasy=3
    }

    // questo è un elenco che corrisponde a dei numeri
}
