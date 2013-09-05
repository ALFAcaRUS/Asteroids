using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Entitys.bullets;
using System.Text;
using Game;

[assembly: InternalsVisibleTo("AsteroidsTest")]

namespace Game.Entitys.Enemies
{

    internal class Asteroid : AEntity
    {
        private readonly int _parts = 2;

        public Asteroid(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
            : base(pos, size, speed)
        {

        }

        public Asteroid(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, int parts)
            : base(pos, size, speed)
        {
            this._parts = parts;
        }

        internal override void ChengeState(CoupleDouble maxPos)
        {
            Pos = Pos + Speed;
            Pos.X = Math.Abs(Pos.X) > maxPos.X
                ? Math.Sign(Pos.X)*(maxPos.X - Math.Abs(Pos.X))
                : Pos.X;
            Pos.Y = Math.Abs(Pos.Y) > maxPos.Y
                ? Math.Sign(Pos.Y) * (maxPos.Y - Math.Abs(Pos.Y))
                : Pos.Y;
        }

        internal override List<AEntity> Interaction(AEntity interactionEntity)
        {
            if (typeof(LaserBullet) == interactionEntity.GetType() || typeof(GunBullet) == interactionEntity.GetType())
            {
                base.WasKilled = true;
                if (_parts > 1)
                {
                    Degree projection = new Degree();

                    projection.SetProjections(Speed);

                    List<AEntity> output = new List<AEntity>();
                    output.Add(new Asteroid(this.Pos, this.Size, (projection + 45).GetProjections(), _parts - 1));
                    output.Add(new Asteroid(this.Pos, this.Size, (projection - 45).GetProjections(), _parts - 1));

                    return output;
                }
            }
            return null;
        }

        internal override EntityType GetEntityType()
        {
            return EntityType.Enemy;
        }

        public override string ToString()
        {
            return new StringBuilder("Asteroid{0}",_parts).ToString();
        }
    }
}
