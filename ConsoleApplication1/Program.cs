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
        static void Main(string[] args){

            StartGame();
            Console.ReadKey();
        }

        // starten van het spel
        public static void StartGame(){
            Console.WriteLine("TicTacToe begint");
            Console.WriteLine(board); // board laten zien
            Turn(); // eerste beurt
        }

        public static void Turn(){
            // Op het moment dat een turn plaatsvind: Controleer de gamestatus
            // Aan de hand van de gamestatus verander de knop etc.
            // Op het moment dat  de Gamestatus Win of Equal retourneert, genereer boodschap en reset.
            Console.WriteLine(status); 
            Console.WriteLine(kiesVak);
            input = GetPlayerInput()-1; 
            // checken of er een geldig getal is in gevoerd
            if (input < 0 || input > 8)
                {
                Console.WriteLine("Ongeldig getal"); // bij ongeldig getal begint de beurt opnieuw
                Turn();
            }
            else
            {
            if (TicTacToeEngine.TictacToeEngine.SetCell(input)) {
                    switch (TicTacToeEngine.TictacToeEngine.status) {
                        case GameStatus.PlayerXPlays: UpdateBoard(); Console.WriteLine(TicTacToeEngine.TictacToeEngine.Board()); Turn(); break;
                        case GameStatus.PlayerOPlays: UpdateBoard(); Console.WriteLine(TicTacToeEngine.TictacToeEngine.Board()); Turn(); break;
                        case GameStatus.PlayerOWins: UpdateBoard(); Console.WriteLine(TicTacToeEngine.TictacToeEngine.Board()); Console.WriteLine("O wint"); Reset(); break;
                        case GameStatus.PlayerXWins: UpdateBoard(); Console.WriteLine(TicTacToeEngine.TictacToeEngine.Board()); Console.WriteLine("X wint"); Reset(); break;
                        case GameStatus.Equal: UpdateBoard(); Console.WriteLine(TicTacToeEngine.TictacToeEngine.Board()); Console.WriteLine("niemand wint"); Reset(); ; break;
                    } 
                }   
            }
        }

       public static void Reset()
        {

                Console.WriteLine("Bord wordt geleegd");
                TicTacToeEngine.TictacToeEngine.Reset();
                board = UpdateBoard();
                Console.WriteLine("Nieuw spel wordt gestart");
                StartGame();

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
