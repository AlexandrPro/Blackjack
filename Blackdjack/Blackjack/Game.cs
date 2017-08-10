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
        public int PlayerWinsCount { get; private set; }
        public int DealerWinsCount { get; private set; }

        public int PlayerPointsCount { get { return player.PointCount; } } 
        public int DealerPointsCount { get { return dealer.PointCount; } }

        public bool isShuffleActive { get; private set; }

        public Game(int countOfDecks = 1)
        {
            isShuffleActive = false;
            PlayerWinsCount = DealerWinsCount = 0;
            shoe = new Shoe(1);
            player = new Hand();
            dealer = new Hand();
        }

        public void NewGame()
        {
            //if(shoe.isEmpty)
            //Как передать это состояние на UI?
            isShuffleActive = true;
            player.Clean();
            dealer.Clean();
            Card card;
            for (int i = 0; i < 2; i++)
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

            while(dealer.PointCount < 17)
            {
                Card card = shoe.TakeCard();
                dealer.AddCard(card, CardValue(card));
            }

            if(player.PointCount > dealer.PointCount 
                || dealer.PointCount > 21)
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
            switch (card.type)
            {
                case CardType.Two:
                    return 2;
                case CardType.Three:
                    return 3;
                case CardType.Four:
                    return 4;
                case CardType.Five:
                    return 5;
                case CardType.Six:
                    return 6;
                case CardType.Seven:
                    return 7;
                case CardType.Eight:
                    return 8;
                case CardType.Nine:
                    return 9;
                case CardType.Ten:
                    return 10;
                case CardType.King:
                    return 10;
                case CardType.Queen:
                    return 10;
                case CardType.Jack:
                    return 10;
                case CardType.Ace: //как сделать, чтоб выбирал игрок?
                    if (player.PointCount < 11)
                        return 11;
                    else
                        return 1;
                default:
                    return 0;
            }
        }

        void endStep()
        {
            if (player.PointCount == 21)
            {
                PlayerWin();
            }
            if (player.PointCount > 21)
            {
                DealerWin();
            }
        }

        void PlayerWin()
        {
            PlayerWinsCount++;
            isShuffleActive = false;
        }

        void DealerWin()
        {
            DealerWinsCount++;
            isShuffleActive = false;
        }
    }
}
