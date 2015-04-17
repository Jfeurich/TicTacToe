using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeEngine;

namespace WindowsFormsApplication2
{
    public partial class BoterKaasEnEieren : Form
    {
        public static  GameStatus status = GameStatus.PlayerOPlays;
        public static TictacToeEngine tte = new TictacToeEngine();
        public static int beurt;

        public BoterKaasEnEieren()
        {
            InitializeComponent();
           
        }

        private void button_Click(object sender, EventArgs e)
        {          
            // tictactoe engine aanroepen
            Button button = sender as Button;
            int tabindex = button.TabIndex;
            checkCell(tabindex, sender);
        }

        public static void checkCell(int tabindex, object sender)
        {
            tabindex++;
            Button b = sender as Button;
            switch (status)
            {
                case GameStatus.PlayerOPlays:
                    b.Text = "O";
                    b.Enabled = false;
                    status = GameStatus.PlayerXPlays;
                    beurt++;
                    System.Windows.Forms.MessageBox.Show("" + tabindex);
                    TicTacToeEngine.TictacToeEngine.SetCell(tabindex, status);
                    if (TicTacToeEngine.TictacToeEngine.CheckWinner())
                    {

                        System.Windows.Forms.MessageBox.Show(" O heeft GEWONNEN");
                        TicTacToeEngine.TictacToeEngine.Reset();
                        ResetForm();

                    }
                    else
                    {
                        if (TicTacToeEngine.TictacToeEngine.CheckEqual())
                        {
                            System.Windows.Forms.MessageBox.Show("Gelijk spel");
                            TicTacToeEngine.TictacToeEngine.Reset();
                            ResetForm();

                        }
                    }
                    break;

                case GameStatus.PlayerXPlays:
                    b.Text = "X";
                    b.Enabled = false;
                    status = GameStatus.PlayerOPlays;
                    TicTacToeEngine.TictacToeEngine.SetCell(tabindex, status);
                    System.Windows.Forms.MessageBox.Show("" + tabindex);
                    beurt++;
                    TicTacToeEngine.TictacToeEngine.SetCell(tabindex, status);
                    if (TicTacToeEngine.TictacToeEngine.CheckWinner())
                    {
                        System.Windows.Forms.MessageBox.Show(" X heeft GEWONNEN");
                        TicTacToeEngine.TictacToeEngine.Reset();
                        ResetForm();
                    }
                    break;
            }        
        }

        public static void ResetForm()
        {
            Application.Restart();          
        }
    }
}
