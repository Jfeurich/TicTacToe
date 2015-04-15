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
           /* if (!boardposition[position].Equals('X') || !boardposition[position].Equals('O'))
            {
                Console.WriteLine("Veld is leeg");
                return true;
            }
            if(boardposition[position].Equals('X') || boardposition[position].Equals('O'))
            {
                Console.WriteLine("Er staat al een X of een O");
                return false;
            }*/
            //return false;
            /*i = i - 1;
            if (boardposition[i] != null)
            {
                return false;
            }
            else
            {
                return true;
            }*/
            
        }

        public static void Reset()
        {
            Array.Clear(boardposition, 9, boardposition.Length);
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
           /* Console.WriteLine(i);
            string statusString = "OX";
            char O = statusString[0];
            char X = statusString[1];

            if (status == GameStatus.PlayerOPlays)
            {
                boardposition[i] = 'O';
            }
            else if (status == GameStatus.PlayerXPlays)
            {
                boardposition[i] = X;
            }
        }

        public static bool CheckWinner()
        {
            if ((boardposition[0] == boardposition[1] && boardposition[0] == boardposition[2])
                || (boardposition[0] == boardposition[3] && boardposition[0] == boardposition[6])
                || (boardposition[0] == boardposition[4] && boardposition[0] == boardposition[8])
                || (boardposition[1] == boardposition[4] && boardposition[1] == boardposition[7])
                || (boardposition[2] == boardposition[4] && boardposition[2] == boardposition[6])
                || (boardposition[2] == boardposition[5] && boardposition[2] == boardposition[8])
                || (boardposition[3] == boardposition[4] && boardposition[3] == boardposition[5])
                || (boardposition[6] == boardposition[7] && boardposition[6] == boardposition[8]))
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
