using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    public class Game : IGame
    {
        Shoe shoe;
        Hand player;
        Hand dealer;
        GameState gameState;
        

        public int PlayerPointsCount { get { return player.PointCount; } }
        public int DealerPointsCount { get { return dealer.PointCount; } }

        public bool isShuffleActive { get; private set; }

        public Game(int countOfDecks = 1)
        {
            isShuffleActive = false;
            //PlayerWinsCount = DealerWinsCount = 0;
            shoe = new Shoe(1);
            player = new Hand();
            dealer = new Hand();
            gameState = new GameState { PlayerWinsCount = 0, DealerWinsCount = 0 };
        }

        public void NewGame()
        {
            //if(shoe.isEmpty)
            //Как передать это состояние на UI?
            isShuffleActive = true;
            player.Clean();
            dealer.Clean();
            Card card;
            for (int i = 0; i < Constants.CountOfStartCards; i++)
            {
                card = shoe.TakeCard();
                player.AddCard(card, CardValue(card));
            }
            card = shoe.TakeCard();
            dealer.AddCard(card, CardValue(card));


            endStep();
        }
        

        public void Hit()
        {
            //if(shoe.isEmpty)
            //Как передать это состояние на UI?

            Card card = shoe.TakeCard();
            player.AddCard(card, CardValue(card));
            card = shoe.TakeCard();
            dealer.AddCard(card, CardValue(card));

            endStep();
        }

        public void Stand()
        {
            //if(shoe.isEmpty)
            //Как передать это состояние на UI?

            while(dealer.PointCount < Constants.MaxPointsForDealerHitting)
            {
                Card card = shoe.TakeCard();
                dealer.AddCard(card, CardValue(card));
            }

            if(player.PointCount > dealer.PointCount 
                || dealer.PointCount > Constants.MaxPointsCount)
            {
                PlayerWin();
            }
            else
            {
                DealerWin();
            }
        }
        
        int CardValue(Card card)
        {
            Dictionary<CardType, int> cardTypesValue = new Dictionary<CardType, int>
            {
                {CardType.Two, 2 },
                {CardType.Three, 3 },
                {CardType.Four, 4 },
                {CardType.Five, 5 },
                {CardType.Six, 6 },
                {CardType.Seven, 7 },
                {CardType.Eight, 8 },
                {CardType.Nine, 9 },
                {CardType.Ten, 10 },
                {CardType.King, 10 },
                {CardType.Queen, 10 },
                {CardType.Jack, 10 }
            };

            if (card.Type == CardType.Ace)
            {
                if (player.PointCount < Constants.MaxPointsForAceCostingEleven)
                    return 11;
                else
                    return 1;
            }
            else
            {
                return cardTypesValue[card.Type];
            }
        }

        void endStep()
        {
            if (player.PointCount == Constants.MaxPointsCount)
            {
                PlayerWin();
            }
            if (player.PointCount > Constants.MaxPointsCount)
            {
                DealerWin();
            }
        }

        void PlayerWin()
        {
            gameState.PlayerWinsCount++;
            isShuffleActive = false;
        }

        void DealerWin()
        {
            gameState.DealerWinsCount++;
            isShuffleActive = false;
        }
    }
}
