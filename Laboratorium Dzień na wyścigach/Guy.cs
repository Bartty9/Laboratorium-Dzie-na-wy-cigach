using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorium_Dzień_na_wyścigach
{
    public class Guy
    {
        public string Name;     //imię faceta
        public Bet MyBet;       //Instancja klasy Bet przechowująca dane o zakładzie
        public int Cash;        //Jak dużo pieniędzy posiada
        
        public RadioButton MyRadioButton;   //moje pole wyboru
        public Label MyLabel;               //Moja etykieta

        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " ma " + Cash + "zł";
            if (MyBet == null)
            {
                MyLabel.Text = Name + " nie zawarł zakładu.";
            }
            else
            {
                MyLabel.Text = Name + " stawia " + MyBet.Amount + " zł na charta numer " + ++MyBet.Dog + ".";
                MyBet.Dog--;
            }
        }

        public void ClearBet()
        {
            MyBet = null;   //Wyczyść zakład aby był równy zero
        }

        public void PlaceBet(int Amount, int DogToWin)
        {
            if (this.Cash >= Amount)
            {
                MyBet = new Bet() { Amount = Amount, Dog = DogToWin, Bettor = this };             //ustal nowy zakład i przechowaj go w polu MyBet
                
            }
            else
            {
                MessageBox.Show(Name + " nie ma tyle kasy żeby postawić.");
                
            }
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
            UpdateLabels();                 //poprość o wypłatę zakładu i zaktualizuj etykiety
        }
    }
}
