using System.Collections.Generic;
using System;

namespace Game.Maine
{
    public interface IGame
    {
        event EventHandler<LooseEventArgs> PlayerLoose;

        List<ViewObject> Tick(List<UserAction> actions);
    }
}
