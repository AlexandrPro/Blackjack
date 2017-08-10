using Blackdjack.Blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Do(game);
        }

        static void Do(Game game)
        {
            bool isFinished = false;
            do
            {
                PrintGameState(game);
                if (game.isShuffleActive)
                {
                    PlayerChoice(game);
                }
                else
                {
                    PrintWins(game);
                    Console.WriteLine("----New Shuffle----");
                    game.NewGame();
                }
            } while (!isFinished);
        }

        private static void PlayerChoice(Game game)
        {
            Console.WriteLine("1 - Еще, 2 - Хватит, 3 - Кол-во побед");
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case '1':
                    game.Hit();
                    break;
                case '2':
                    game.Stand();
                    break;
                default:
                    break;
            }
        }

        static void PrintGameState(Game game)
        {
            Console.WriteLine("Игрок " + game.PlayerPointsCount + " : " 
                + game.DealerPointsCount + " Дилер");
            
        }
        static void PrintWins(Game game)
        {
            Console.WriteLine("Победы: Игрок " + game.PlayerWinsCount
                       + " | " + game.DealerWinsCount + " Дилер");
        }
    }
}
