using Blackdjack.Blackjack;
using Blackdjack.ConsoleUI;
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
                //PrintGameState(game);
                MyConsoleUI.PrintShuffleScore(game.PlayerPointsCount, game.DealerPointsCount);
                if (game.isShuffleActive)
                {
                    PlayerChoice(game);
                    //TODO
                }
                else
                {
                    MyConsoleUI.PrintWins(GameState.PlayerWinsCount, GameState.DealerWinsCount);
                    MyConsoleUI.PrintStartShuffle();
                    game.NewGame();
                }
            } while (!isFinished);
        }

        private delegate void playerAction();
        private static void PlayerChoice(IGame game)
        {
            Dictionary<PlayerChoisces, playerAction> operations = new Dictionary<PlayerChoisces, playerAction>
            {
                {PlayerChoisces.Hit, game.Hit },
                {PlayerChoisces.Stand, game.Stand }
            };

            operations[MyConsoleUI.AskPlayerChoice()].Invoke();
        }
    }
}
