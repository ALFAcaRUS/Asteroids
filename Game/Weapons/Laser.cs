using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entitys;
using Game.Entitys.bullets;

namespace Game.Weapons
{
    class Laser : IWeapon
    {
        public int Charge { get; set; }
        public int Distance { get; set; }

        public Laser()
        {
            Charge = 1;
            Distance = 1;
        }

        public List<AEntity> Shot(CoupleDouble pos, Degree direction)
        {
            if (Charge > 0)
            {
                --Charge;
                List<AEntity> output = new List<AEntity>();
                CoupleDouble positions = new CoupleDouble(pos.X, pos.Y);

                for (int i = 0; i < Distance; i++)
                {
                    output.Add(new LaserBullet(positions, CoupleDouble.ones, CoupleDouble.zero));
                    positions = positions + (positions*direction.GetProjections());
                }

                return output.Count != 0 ? output : null;
            }
            else
            {
                return null;
            }
        }
    }
}
