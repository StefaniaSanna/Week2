using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrente
{
     public class Conto
    {
        public string Intestatario { get; set; }
        public TipoConto TipoConto { get; set; }
        public double Saldo { get; set; }
        public int NumeroConto { get; set; }

    }

    public enum TipoConto
    {
        Corrente =1,
        Risparmi=2
    }
}
