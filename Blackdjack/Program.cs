using Blackdjack.Blackjack;
using Blackdjack.IoC;
using Ninject;
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
            IKernel kernel = new StandardKernel(new BlackjackNinjectModule());

            IGame game = kernel.Get<Game>();
            Do(game);
        }

        static void Do(IGame game)
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

        private static void PlayerChoice(IGame game)
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

        static void PrintGameState(IGame game)
        {
            Console.WriteLine("Игрок " + game.PlayerPointsCount + " : " 
                + game.DealerPointsCount + " Дилер");
            
        }
        static void PrintWins(IGame game)
        {
            Console.WriteLine("Победы: Игрок " + game.PlayerWinsCount
                       + " | " + game.DealerWinsCount + " Дилер");
        }
    }
}
