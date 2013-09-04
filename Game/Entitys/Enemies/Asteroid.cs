using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entitys.bullets;

[assembly: InternalsVisibleTo("AsteroidsTest")]

namespace Game.Entitys.Enemies
{

    internal class Asteroid : AEntity
    {
        private int _parts = 2;

        public Asteroid(CoupleInt pos, CoupleInt size, CoupleInt speed)
            : base(pos, size, speed)
        {

        }

        public Asteroid(CoupleInt pos, CoupleInt size, CoupleInt speed, int parts)
            : base(pos, size, speed)
        {
            this._parts = parts;
        }

        internal override void ChengeState()
        {
            this.Pos.X = this.Pos.X + this.Speed.X;
            this.Pos.Y = this.Pos.Y + this.Speed.Y;
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof(LaserBullet) == interactionEntity.GetType() || typeof(GunBullet) == interactionEntity.GetType())
            {
                base.WasKilled = true;
                if (_parts > 1)
                {

                    List<AEntity> output = new List<AEntity>
                    {
                        new Asteroid(this.Pos, this.Size, new CoupleInt(this.Speed.X + 1,this.Speed.Y), this._parts - 1),
                        new Asteroid(this.Pos, this.Size, new CoupleInt(this.Speed.X - 1,this.Speed.Y), this._parts - 1)
                    };

                    return output;
                }
            }
            return null;
        }
    }
}
