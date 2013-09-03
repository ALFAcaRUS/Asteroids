using System;
using System.Collections.Generic;
using Game.Entitys;
using Game.Ships;

namespace Game.Maine
{
    internal class MainClass:IGame
    {
        private UInt64 Score;
        private List<AEntity> Entitys;
        private IShip playerShip;

        public MainClass(List<AEntity> startEntitys, IShip startPlayerShip)
        {
            
        }

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
