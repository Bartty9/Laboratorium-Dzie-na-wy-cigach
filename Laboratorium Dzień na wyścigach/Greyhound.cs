using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorium_Dzień_na_wyścigach
{
    public class Greyhound
    {
        public int StartingPosition; //Miejsce, gdzie rozpoczyna się PictureBox
        public int RacetrackLength; //Jak długa jest trasa
        public PictureBox MyPictureBox = null;  //Mój obiekt PictureBox
        public int Location = 22;    //Moje położenie na torze wyścigowym
        public Random MyRandom;     //instancja klasy Random

        public bool Run()
        {
            StartingPosition += MyRandom.Next(1, 7);    //Przesuń się do przodu o losowo 1,2,3,4,5 lub 6 punktów
            MyPictureBox.Left = StartingPosition;       //Zaktualizuj położenie PictureBox na formularzu
            if (StartingPosition >= RacetrackLength )   
            {
                return true; //zwróc true jeżeli wygrałem wyścig
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            MyPictureBox.Left = Location;
            StartingPosition = Location;
        }
    }
}
