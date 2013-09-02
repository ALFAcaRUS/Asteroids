using System;
using System.Collections.Generic;
using Game.Entitys;

namespace Game.Maine
{
    internal class MainClass:IGame
    {
        private UInt64 Score;
        private List<AEntity> Entitys;

        public List<ViewObject> Tick(List<UserAction> actions)
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            throw new NotImplementedException();
        }
    }
}
