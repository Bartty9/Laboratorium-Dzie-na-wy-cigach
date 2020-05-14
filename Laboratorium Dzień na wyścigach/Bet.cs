using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium_Dzień_na_wyścigach
{
    public class Bet
    {
        public int Amount; //Ilość postawionych pieniędzy
        public int Dog;     //numer psa, na którego postawiono
        public Guy Bettor;  //Facet który zawarł zakład

        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;          //Parametrem jest zwycięzca wyścigu. Jeżeli pies wygrał, 
            }                           //zwróć wartość postawioną. W przeciwnym razie zwróc wartość postawioną ze znakiem minus
            else
            {
                return -Amount;
            }   
        }
    }
}
