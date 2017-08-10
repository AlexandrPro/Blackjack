using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    interface IGame
    {
        void NewGame();
        int PlayerPointsCount { get; }
        int DealerPointsCount { get; }
        bool isShuffleActive { get; }
        void Hit();
        void Stand();
    }
}
