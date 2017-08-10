using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    public class Shoe
    {
        List<Card> cards = new List<Card>();

        public Shoe(int countOfDecks)
        {
            for (int i = 0; i < countOfDecks; i++)
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                    {
                        cards.Add(new Card { Type = type, Suit = suit });
                    }
                }
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random random = new Random();
            for (int i = cards.Count - 1; i >= 1; i--)
{
                int j = random.Next(i + 1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        public Card TakeCard()
        {
            try
            {
                Card card = cards.Last();
                cards.Remove(card);
                return card;
            }
            catch
            {
                throw;
            }
        }

        public bool isEmpty()
        {
            if (cards.Count == 1)
                return true;
            else
                return false;
        }
    }
}
