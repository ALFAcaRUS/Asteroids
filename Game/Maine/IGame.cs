using System;
using System.Collections.Generic;
using Game.Support;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Maine
{
    public interface IGame
    {
        List<ViewObject> Tick(List<UserAction> actions);
        void NewGame();

    }
}
