using System;
using System.Collections.Generic;

namespace Game.Entitys
{
    abstract internal class AEntity
    {
        internal virtual CoupleDouble Pos { get; set; }
        internal virtual CoupleDouble Size { get; set; }
        internal virtual CoupleDouble Speed { get; set; }
        internal virtual Boolean WasKilled { get; set; }

        Degree _angle = new Degree(0);

        internal Degree Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
            }
        }

        internal AEntity(CoupleDouble pos, CoupleDouble size, CoupleDouble speed)
        {
            this.Pos = pos;
            this.Size = size;
            this.Speed = speed;
            WasKilled = false;
        }

        internal AEntity(CoupleDouble pos, CoupleDouble size, CoupleDouble speed, Degree angle)
        {
            Pos = pos;
            Size = size;
            Speed = speed;
            _angle = angle;
            WasKilled = false;
        }

        internal abstract void ChengeState(CoupleDouble maxPos);

        internal abstract List<AEntity> Interaction(AEntity interactionEntity);

        internal abstract EntityType GetEntityType();

        internal ViewObject GetViewObject()
        {
            return new ViewObject(this.ToString(), Pos, Size, Angle);
        }
    }
}
