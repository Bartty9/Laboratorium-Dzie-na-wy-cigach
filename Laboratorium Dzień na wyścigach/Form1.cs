using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorium_Dzień_na_wyścigach
{
    public partial class Form1 : Form
    {
        Greyhound[] greyhounds = new Greyhound[4];
        Guy[] guys = new Guy[3];
        Random Randomizer = new Random();
        public Form1()
        {
            InitializeComponent();
            greyhounds[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = pictureBox1.Width - pictureBox2.Width,
                MyRandom = Randomizer
            };
            greyhounds[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = pictureBox1.Width - pictureBox3.Width,
                MyRandom = Randomizer
            };
            greyhounds[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = pictureBox1.Width - pictureBox4.Width,
                MyRandom = Randomizer
            };
            greyhounds[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = pictureBox1.Width - pictureBox5.Width,
                MyRandom = Randomizer
            };
            guys[0] = new Guy() { Name = "Joe", Cash = 5, MyBet = null, MyLabel = joeBetLabel, MyRadioButton = joeRadioButton };
            guys[1] = new Guy() { Name = "Bob", Cash = 75, MyBet = null, MyLabel = bobBetLabel, MyRadioButton = bobRadioButton};
            guys[2] = new Guy() { Name = "Al", Cash = 45, MyBet = null, MyLabel = alBetLabel, MyRadioButton = alRadioButton};
            guys[0].UpdateLabels();
            guys[1].UpdateLabels();
            guys[2].UpdateLabels();
            minimumBetLabel.Text = "Minimalny zakład: " + numericUpDown1.Minimum + "zł";
            if (joeRadioButton.Checked)
            {
                nameLabel.Text = guys[0].Name;
            }
            if (bobRadioButton.Checked)
            {
                nameLabel.Text = guys[1].Name;
            }
            if (alRadioButton.Checked)
            {
                nameLabel.Text = guys[2].Name;
            }
        }

      
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (greyhounds[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Wygrał " + ++i + " pies.");
                    i--;
                    for (int j = 0; j < guys.Length; j++)
                    {
                        if (guys[j].MyBet != null)
                        {
                            guys[j].Collect(i);
                            guys[j].ClearBet();
                            guys[j].UpdateLabels();
                        }
                    }                                            
                    for (int j = 0; j < 4; j++)
                    {
                        greyhounds[j].TakeStartingPosition();
                    }
                    groupBox1.Enabled = true;
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[0].Name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[1].Name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = guys[2].Name;
        }

        private void button1_Click(object sender, EventArgs e)      //GO! button
        {
            timer1.Start();
            groupBox1.Enabled = false;
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                guys[0].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value - 1);
                guys[0].UpdateLabels();
            }
            if (bobRadioButton.Checked)
            {
                guys[1].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value - 1);
                guys[1].UpdateLabels();
            }
            if (alRadioButton.Checked)
            {
                guys[2].PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value - 1);
                guys[2].UpdateLabels();
            }
            
        }
    }
}
