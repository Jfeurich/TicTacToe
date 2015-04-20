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

        private void button_Click(object sender, EventArgs e) {
            // tictactoe engine aanroepen
            Button button = sender as Button;
            int tabindex = button.TabIndex++;
            
            // Op het moment dat er op een knop gedrukt wordt: Controleer de gamestatus
            // Aan de hand van de gamestatus verander de knop etc.
            // Op het moment dat  de Gamestatus Win of Equal retourneert, genereer boodschap en reset.
         if (TicTacToeEngine.TictacToeEngine.SetCell(tabindex)) {
                 switch (TicTacToeEngine.TictacToeEngine.status) {
                        case GameStatus.PlayerXPlays: button.Text = "O"; button.Enabled = false; ; break;
                        case GameStatus.PlayerOPlays: button.Text = "X"; button.Enabled = false; ; break;
                        case GameStatus.PlayerOWins: System.Windows.Forms.MessageBox.Show("O wint"); ResetForm(); break;
                        case GameStatus.PlayerXWins: System.Windows.Forms.MessageBox.Show("X wint"); ResetForm(); break;
                        case GameStatus.Equal: System.Windows.Forms.MessageBox.Show("Gelijkspel"); ResetForm(); break;
                    } 
                }      
            }
        public void ResetForm(){
        foreach (Control c in Controls) {
            c.Enabled = true;
            c.Text = "";
            TicTacToeEngine.TictacToeEngine.Reset();
            }         
        }
    }
}
