using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }


    public class TictacToeEngine
    {
        // array aanmaken met 9 plaatsen

        public GameStatus status { get; set; }
        public static char[] boardposition = new char[9];

        public static string board;
       
        public static bool ChooseCell(int i)
        {
            int position = i - 1;

            if (position > boardposition.Length)
            {
                System.Console.WriteLine("Onbekend getal ingevuld");
                return false;
            }
           // Console.WriteLine(boardposition[position]);
            else if (boardposition[position].Equals('O') || boardposition[position].Equals('X'))
            {
                return false;
            }
            else
            {
                return true;
            }
            return false;         
        }

        public static void Reset()
        {
            
            Array.Clear(boardposition,0, boardposition.Length);
        }

        public static string Board()
        {
            // board tekenen
            board = "------------- \n| " +
                boardposition[0] + " | " + boardposition[1] + " | " + boardposition[2] + " |\n| " +
                boardposition[3] + " | " + boardposition[4] + " | " + boardposition[5] + " |\n| " +
                boardposition[6] + " | " + boardposition[7] + " | " + boardposition[8] + " |\n" +
                "-------------";
            return board;
        }

        public static void SetCell(int i, GameStatus status)
        {
            i = i - 1;
            if (status == GameStatus.PlayerOPlays)
            {
                boardposition[i] = 'O';
                //Console.WriteLine(boardposition[i]);
            }
            if (status == GameStatus.PlayerXPlays)
            {
                boardposition[i] = 'X';
                //Console.WriteLine(boardposition[i]);
            }
        }

        public Boolean bepaalWinnaar(char a, char b, char c)
        {
            if((a.Equals(b)) && a.Equals(c)) && !a == "")

                )
        }
        public static bool CheckWinner()
        {

            /*if((boardposition[0].Equals(boardposition[1]) && boardposition[2].Equals(boardposition[0]) && boardposition[0]!= null))
            {

                return true;
            }
            return false;*/
           /* if ((boardposition[0] == 'X' && boardposition[1] == 'X' && boardposition[2] == 'X' )||
            
               (boardposition[0] == 'O' && boardposition[1] == 'O' && boardposition[2] == 'O'))
            {
                
                return true;
            }
            return false;*/
            /* if ((boardposition[0] == boardposition[1] && boardposition[0] == boardposition[2] && boardposition[0] != null)
                 || (boardposition[0] == boardposition[3] && boardposition[0] == boardposition[6] && boardposition[0] != null)
                 || (boardposition[0] == boardposition[4] && boardposition[0] == boardposition[8] && boardposition[0] != null)
                 || (boardposition[1] == boardposition[4] && boardposition[1] == boardposition[7] && boardposition[1] != null)
                 || (boardposition[2] == boardposition[4] && boardposition[2] == boardposition[6] && boardposition[2] != null)
                 || (boardposition[2] == boardposition[5] && boardposition[2] == boardposition[8] && boardposition[2] != null)
                 || (boardposition[3] == boardposition[4] && boardposition[3] == boardposition[5] && boardposition[3] != null)
                 || (boardposition[6] == boardposition[7] && boardposition[6] == boardposition[8] && boardposition[6] != null))
             {
                 return true;
             }
             return false;*/
        }

        public static bool CheckEqual()
        {
            foreach (char c in boardposition)
            {
                if (c == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
