using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    public class Hand
    {
        List<Card> cards = new List<Card>();
        int pointsValue = 0;
        public int PointCount {  get { return pointsValue; } }

        public void AddCard(Card card, int cardValue)
        {
            cards.Add(card);
            pointsValue += cardValue;
        }

        public void Clean()
        {
            cards = new List<Card>();
            pointsValue = 0; 
        }
    }
}
