using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Support;
using Game.Entitys;

namespace Game.Maine
{
    internal class Game:IGame
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
