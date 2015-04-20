using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public enum GameStatus { PlayerOPlays, PlayerXPlays, Equal, PlayerOWins, PlayerXWins }


    public class TictacToeEngine{
        public static GameStatus status { get; set; }
        public static char[] boardposition = new char[9];
        public static string board;

        public static bool SetCell(int i) {
            int position = i;
            if (position > boardposition.Length) {
                System.Console.WriteLine("Onbekend getal ingevuld");
                return false;
                }
            else if (boardposition[position].Equals('O') || boardposition[position].Equals('X')){
                return false;
                }
            else {
                //hier wordt de zet gedaan, na de zet wordt de status aangepast 
                // en gecontroleerd of er een winnaar is.
                if (status == GameStatus.PlayerOPlays) {
                    boardposition[position] = 'O';
                    if (CheckEqual()) {
                        status = GameStatus.Equal;
                        }
                    else if (!CheckWinner()) {
                        status = GameStatus.PlayerXPlays;
                        }
                    else if (CheckWinner()) {
                        status = GameStatus.PlayerOWins;
                        }
                     
                    }
                else if (status == GameStatus.PlayerXPlays) {
                    boardposition[position] = 'X';
                    if (CheckEqual()) {
                        status = GameStatus.Equal;
                        }
                    if (!CheckWinner()) {
                        status = GameStatus.PlayerOPlays;
                        }
                    else if (CheckWinner()) {
                        status = GameStatus.PlayerXWins;
                        }
                    }   
                    return true;
                    }
             }
            

        public static void Reset()
        {        
            Array.Clear(boardposition,0, boardposition.Length);
            status = GameStatus.PlayerOPlays;
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
