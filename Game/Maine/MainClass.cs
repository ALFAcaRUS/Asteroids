using System;
using System.Collections.Generic;
using System.Linq;
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
            Entitys = startEntitys;
            playerShip = startPlayerShip;
            Score = 0;
        }

        public List<ViewObject> Tick(List<UserAction> actions)
        {
            throw new NotImplementedException();
        }

        private List<AEntity> Interactions()
        {
            List<AEntity> outPut = new List<AEntity>();

            // for each entity in Entitys try interaction whith every entity in same position 
            foreach (AEntity entyty in Entitys)
            {
                // Create list of entitys in same position
                List<AEntity> interaction = Entitys.FindAll(x => x.Pos.Equals(entyty.Pos));

                // If list not empty try react
                if ( 0 != interaction.Count)
                {
                    foreach (AEntity intEntity in interaction)
                    {
                        List<AEntity> intResult = entyty.Interaction(intEntity);

                        if(null != intResult) outPut.AddRange(intResult);
                    }
                }
            }

            return outPut;
        }
    }
}
