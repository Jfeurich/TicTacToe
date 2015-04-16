using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeEngine;

namespace ConsoleApplication1
{
    class Program
    {
        public static GameStatus status = GameStatus.PlayerOPlays;
        public static string board = UpdateBoard();
        public const string kiesVak = "Kies een vak (1-9)";
        public static bool result = false;
        public static int input;
        //   public static int countTurns;
        static void Main(string[] args)
        {

            StartGame();
            Console.ReadKey();
            /*string line = Console.ReadLine();
            while (!line.Equals("exit"))
            {
                //  Turn();
            }*/
        }

        public static void StartGame()
        {
            Console.WriteLine("TicTacToe begint");
            Console.WriteLine(board);
            Turn();

        }

        public static void Turn()
        {
            Console.WriteLine(status); 
            Console.WriteLine(kiesVak);
            input = GetPlayerInput(); 
            if (input < 1 || input > 9)
            {
                Console.WriteLine("Ongeldig getal");
                Turn();
            }
            else
            {
                result = TicTacToeEngine.TictacToeEngine.ChooseCell(input);
                Console.WriteLine(result);
                if (result)
                {
                    TicTacToeEngine.TictacToeEngine.SetCell(input, status);
                    board = UpdateBoard();
                    Console.WriteLine(board);
                    status = ChangeStatus(status);
                    result = false;
                    if (TicTacToeEngine.TictacToeEngine.CheckWinner())
                    {
                        Console.WriteLine("Gewonnen!");
                        Console.WriteLine("Typ reset om een nieuw spel te starten");
                        string playerinput = Console.ReadLine();
                        checkReset(playerinput);
                    }
                    else {
                        Turn();
                    }

                }
                else
                {
                    Console.WriteLine("Dit vak is al bezet");
                    Turn();
                }
            }
        }

       public static void checkReset(string input)
        {
            if(input == "reset"){
                Console.WriteLine("Bord wordt geleegd");
                TicTacToeEngine.TictacToeEngine.Reset();
                board = UpdateBoard();
                Console.WriteLine("Nieuw spel wordt gestart");
                StartGame();
            }
        }

      

        public static GameStatus ChangeStatus(GameStatus turn)
        {
            switch(turn)
            {
                case GameStatus.PlayerOPlays: turn = GameStatus.PlayerXPlays;
                    break;
                case GameStatus.PlayerXPlays: turn = GameStatus.PlayerOPlays;
                    break;
            }
            return turn;
        }

        public static string UpdateBoard()
        {
            return TicTacToeEngine.TictacToeEngine.Board();
        }

        public static int GetPlayerInput()
        {
            return Int32.Parse(Console.ReadLine());
        }
    }

}
