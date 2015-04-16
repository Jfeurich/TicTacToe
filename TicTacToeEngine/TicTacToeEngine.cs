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
            }
            if (status == GameStatus.PlayerXPlays)
            {
                boardposition[i] = 'X';
            }
        }

        public static Boolean BepaalWinnaar(char a, char b, char c)
        {
            if(a.Equals(b) && a.Equals(c) && !a.Equals('\0')){
                return true;
            }
            return false;

        }

        public static bool CheckWinner()
        {
            if (BepaalWinnaar(boardposition[0], boardposition[1], boardposition[2]) ||
                BepaalWinnaar(boardposition[3], boardposition[4], boardposition[5]) ||
                BepaalWinnaar(boardposition[6],boardposition[7],boardposition[8]) ||
                BepaalWinnaar(boardposition[0],boardposition[3],boardposition[6]) ||
                BepaalWinnaar(boardposition[1], boardposition[4], boardposition[7]) ||
                BepaalWinnaar(boardposition[2],boardposition[5],boardposition[8]) ||
                BepaalWinnaar(boardposition[2], boardposition[4],boardposition[6]) ||
                BepaalWinnaar(boardposition[0],boardposition[4],boardposition[8]))
            {
                return true;
            }
            return false;
        }

        public static bool CheckEqual()
        {
            foreach (char c in boardposition)
            {
                if (c.Equals('\0'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
