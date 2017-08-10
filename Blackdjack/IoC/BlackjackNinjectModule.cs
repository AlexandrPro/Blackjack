using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackdjack.Blackjack;

namespace Blackdjack.IoC
{
    class BlackjackNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IGame>().To<Game>();
        }
    }
}
