using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Game.Entitys;
using Game.Ships;
using Game.Weapons;
using Game;

namespace Game.Maine
{
    internal class MainClass : IGame,IDisposable
    {
        public UInt64 Score {get; private set; }
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

        public event EventHandler<LooseEventArgs> PlayerLoose;

        public List<ViewObject> Tick(List<UserAction> actions)
        {
            Entitys.AddRange(Interactions());
            Entitys.AddRange(ShipState(actions));
            List<ViewObject> output = new List<ViewObject>();
            foreach (AEntity entity in Entitys)
            {
                if ((entity.WasKilled == true) )
                {
                    if (entity.GetEntityType() == EntityType.Enemy)
                    {
                        ViewObject explosion = entity.GetViewObject();
                        explosion.Name = "Exsplosion";
                        output.Add(explosion);
                        Score++;
                    }
                }
                else
                {
                    output.Add(entity.GetViewObject());
                }
            }
            Entitys.RemoveAll(x => x.WasKilled);

            if (!Loose())
            {
                output.Add(new ViewObject("Ship", playerShip.Pos, playerShip.Size, playerShip.Direction));
                foreach (IWeapon weapon in playerShip.Weapons) weapon.Update();

            }
            else
            {
                PlayerLoose(this, new LooseEventArgs(Score));
            }

            return output;
        }

        private List<AEntity> Interactions()
        {
            List<AEntity> outPut = new List<AEntity>();

            // for each entity in Entitys try interaction whith every entity in same position 
            foreach (AEntity entity in Entitys)
            {

                    foreach (AEntity intEntity in Entitys.FindAll(x => PositionsToIntersect(x, entity)))
                    {
                        List<AEntity> intResult = entity.Interaction(intEntity);

                        if (null != intResult) outPut.AddRange(intResult);
                    }
                    entity.ChengeState(MapSize);
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
            double distance = first.Pos.GetDistance(second.Pos);
            CoupleDouble totalSize = first.Size + second.Size;
            return (Math.Abs(distance) < totalSize.X) && (Math.Abs(distance) < totalSize.Y);
        }

        private bool PositionsToIntersect(IShip first, AEntity second)
        {
            double distance = second.Pos.GetDistance(first.Pos);
            CoupleDouble totalSize = first.Size + second.Size;
            return (Math.Abs(distance) < totalSize.X) && (Math.Abs(distance) < totalSize.Y);
        }

        private List<AEntity> ShipState(List<UserAction> actions)
        {
            List<AEntity> output = new List<AEntity>();

            if (null != actions)
            {

                foreach (UserAction action in actions)
                {
                    if (UserActionType.RightShift == action.ActionType) playerShip.Direction += 10;
                    if (UserActionType.LeftShift  == action.ActionType) playerShip.Direction -= 10;
                    if (UserActionType.Forward == action.ActionType)
                    {
                        playerShip.Pos += playerShip.Direction.GetProjections();

                        playerShip.Pos.X = Math.Abs(playerShip.Pos.X)> MapSize.X ? -playerShip.Pos.X : playerShip.Pos.X;
                        playerShip.Pos.Y = Math.Abs(playerShip.Pos.Y) > MapSize.Y ? -playerShip.Pos.Y : playerShip.Pos.Y;
                    }
                    if (UserActionType.Back == action.ActionType)
                    {
                        playerShip.Pos -= playerShip.Direction.GetProjections();

                        playerShip.Pos.X = Math.Abs(playerShip.Pos.X) > MapSize.X ? -playerShip.Pos.X : playerShip.Pos.X;
                        playerShip.Pos.Y = Math.Abs(playerShip.Pos.Y) > MapSize.Y ? -playerShip.Pos.Y : playerShip.Pos.Y;
                    }
                    if (UserActionType.Shoot == action.ActionType)
                    {
                        List<AEntity> shot = playerShip.Weapons[action.Count].Shot(playerShip.Pos, playerShip.Direction);
                        if (null != shot) output.AddRange(shot);
                    }
                }
            }

            return output;
        }

        public void Dispose()
        {
            Entitys.RemoveAll(x => x != null);
        }
    }
}
