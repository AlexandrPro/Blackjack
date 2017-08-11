using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackdjack.Blackjack
{
    public static class GameState
    {
        public static int PlayerWinsCount { get; set; }
        public static int DealerWinsCount { get; set; }

        static GameState()
        {
            PlayerWinsCount = 0;
            DealerWinsCount = 0;
        }
    }
}
