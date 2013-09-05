using System;
using System.Collections.Generic;
using System.Linq;
using Game.Entitys;
using Game.Ships;
using Game;

namespace Game.Maine
{
    internal class MainClass : IGame
    {
        private UInt64 Score;
        private List<AEntity> Entitys;
        private IShip playerShip;
        private CoupleDouble MapSize;

        public MainClass(List<AEntity> startEntitys, IShip startPlayerShip,CoupleDouble mapSize)
        {
            Entitys = startEntitys;
            playerShip = startPlayerShip;
            Score = 0;
            MapSize = mapSize;
        }



        public List<ViewObject> Tick(List<UserAction> actions)
        {
            Entitys.AddRange(Interactions());
            List<ViewObject> output = new List<ViewObject>();
            foreach (AEntity entity in Entitys)
            {
                if ((entity.WasKilled == true) )
                {
                    if (entity.GetEntityType() == EntityType.Enemy)
                    {
                        output.Add(new ViewObject("Explosion", entity.Pos));
                        Score++;
                    }
                }
                else
                {
                    output.Add(new ViewObject(entity.ToString(), entity.Pos));
                }
            }
            Entitys.RemoveAll(x => x.WasKilled);

            if (!Loose())
            {
                output.Add(new ViewObject("ShipPos", playerShip.Pos));
                output.Add(new ViewObject("ShipRot",
                    playerShip.Pos + playerShip.Size*playerShip.Direction.GetProjections()));
                output.Add(new ViewObject("Score", new CoupleDouble(Score, 0)));
            }
            else
            {
                output.Add(new ViewObject("Loose", new CoupleDouble(Score, 0)));
            }

            return output;
        }

        private List<AEntity> Interactions()
        {
            List<AEntity> outPut = new List<AEntity>();

            // for each entity in Entitys try interaction whith every entity in same position 
            foreach (AEntity entyty in Entitys)
            {

                    foreach (AEntity intEntity in Entitys.FindAll(x => PositionsToIntersect(x, entyty)))
                    {
                        List<AEntity> intResult = entyty.Interaction(intEntity);

                        if (null != intResult) outPut.AddRange(intResult);
                    }
                    entyty.ChengeState(MapSize);
            }

            return outPut;
        }




        private bool Loose()
        {
            return
                Entitys.FindAll(x => (x.GetEntityType() == EntityType.Enemy) && (PositionsToIntersect(playerShip, x)))
                    .Count !=0;
        }


        private bool PositionsToIntersect(AEntity first, AEntity second)
        {
            CoupleDouble distance = first.Pos - second.Pos;
            CoupleDouble totalSize = first.Size + second.Size;
            return (distance.X < totalSize.X) || (distance.Y < totalSize.Y);
        }

        private bool PositionsToIntersect(IShip first, AEntity second)
        {
            CoupleDouble distance = first.Pos - second.Pos;
            CoupleDouble totalSize = first.Size + second.Size;
            return (distance.X < totalSize.X) || (distance.Y < totalSize.Y);
        }
    }
}
