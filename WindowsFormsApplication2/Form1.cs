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
        GameStatus status = GameStatus.PlayerOPlays;
        string board = TicTacToeEngine.TictacToeEngine.Board(); 
        public BoterKaasEnEieren()
        {
            InitializeComponent();
            Console.WriteLine("Test");
        }

        private void button_Click(object sender, EventArgs e)
        {
            Console.WriteLine(board);
          
            // tictactoe engine aanroepen
            Button button = sender as Button;
            int tabindex = button.TabIndex;

            if (TicTacToeEngine.TictacToeEngine.ChooseCell(tabindex))
            {
                TicTacToeEngine.TictacToeEngine.SetCell(tabindex, status);
                if (TicTacToeEngine.TictacToeEngine.CheckWinner())
                {
                    if (status == GameStatus.PlayerOPlays)
                    {
                        status = GameStatus.PlayerOWins;
                    }
                    else if (status == GameStatus.PlayerXPlays)
                    {
                        status = GameStatus.PlayerXWins;
                    }
                    Console.WriteLine(status);
                }
                else if (TicTacToeEngine.TictacToeEngine.CheckEqual())
                {
                    status = GameStatus.Equal;
                    Console.WriteLine(status);
                  
                }
                else
                {
                    if (status == GameStatus.PlayerOPlays)
                    {
                        status = GameStatus.PlayerXPlays;
                    }
                    else if (status == GameStatus.PlayerXPlays)
                    {
                        status = GameStatus.PlayerOPlays;
                    }
                }
            }

        }

    }
}
