using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackdjack.Blackjack;

namespace Blackdjack.ConsoleUI
{
    public static class MyConsoleUI
    {
        public static void PrintWins(int playerWinsCount, int dealerWinsCount)
        {
            Console.WriteLine("Победы: Игрок " + playerWinsCount
                       + " | " + dealerWinsCount + " Дилер");
        }

        public static void PrintShuffleScore(int playerPointsCount, int dealerPointsCount)
        {
            Console.WriteLine("Игрок " + playerPointsCount + " : "
                + dealerPointsCount + " Дилер");
        }

        public static void PrintStartShuffle()
        {
            Console.WriteLine("----New Shuffle----");
        }

        public static PlayerChoisces AskPlayerChoice()
        {
            Console.WriteLine("1 - Еще, 2 - Хватит");
            ConsoleKeyInfo key = Console.ReadKey();

            Dictionary<char, PlayerChoisces> playerChoice = new Dictionary<char, PlayerChoisces>
            {
                {'1', PlayerChoisces.Hit },
                {'2', PlayerChoisces.Stand }
            };

            return playerChoice[key.KeyChar];
        }
    }
}
