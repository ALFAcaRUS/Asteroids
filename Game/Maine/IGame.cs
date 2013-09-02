using System.Collections.Generic;

namespace Game.Maine
{
    public interface IGame
    {
        List<ViewObject> Tick(List<UserAction> actions);
        void NewGame();

    }
}
