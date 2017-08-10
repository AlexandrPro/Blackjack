using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    public class Card
    {
        public CardType type;
        public CardSuit suit;

        public Card(CardType type, CardSuit suit)
        {
            this.type = type;
            this.suit = suit;
        }
    }
    
}
