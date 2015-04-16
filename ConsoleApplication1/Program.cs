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
        public static int countTurns;
        static void Main(string[] args)
        {

            StartGame();
            Console.ReadKey();
        }

        // starten van het spel
        public static void StartGame()
        {
            Console.WriteLine("TicTacToe begint");
            Console.WriteLine(board); // board laten zien
            Turn(); // eerste beurt
        }

        public static void Turn()
        {
            Console.WriteLine(status); 
            Console.WriteLine(kiesVak);
            input = GetPlayerInput(); 
            // checken of er een geldig getal is in gevoerd
            if (input < 1 || input > 9)
            {
                Console.WriteLine("Ongeldig getal"); // bij ongeldig getal begint de beurt opnieuw
                Turn();
            }
            else
            {
                // als er een geldig getal is ingevoerd, kijk dan of de cell al bezet is of niet
                result = TicTacToeEngine.TictacToeEngine.ChooseCell(input); 
                
                // als de cel nog niet bezet is dan vul de cel in
                if (result)
                {
                    TicTacToeEngine.TictacToeEngine.SetCell(input, status); // cel invullen 
                    board = UpdateBoard(); 
                    Console.WriteLine(board);// board opnieuw tonen
                    status = ChangeStatus(status);
                    result = false;
                    // kijk of er is gewonnen
                    if (TicTacToeEngine.TictacToeEngine.CheckWinner())
                    {
                        Console.WriteLine("Gewonnen!");
                        Console.WriteLine("Typ reset om een nieuw spel te starten");
                        string playerinput = Console.ReadLine();
                        checkReset(playerinput);
                    }
                    if (TicTacToeEngine.TictacToeEngine.CheckEqual())
                    {
                        Console.WriteLine("Gelijkspel !");
                        Console.WriteLine("Typ reset om een nieuw spel te starten");
                        string playerinput = Console.ReadLine();
                        checkReset(playerinput);
                    }

                    else {
                        countTurns++;
                        Console.WriteLine("Beurtnummer:" + countTurns);
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
