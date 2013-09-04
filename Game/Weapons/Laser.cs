using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entitys;
using Game.Entitys.bullets;

namespace Game.Weapons
{
    class Laser:IWeapon
    {
        public int Charge { get; set; }
        public int Distance { get; set; }

        public Laser()
        {
            Charge = 1;
            Distance = 1;
        }

        public List<AEntity> Shot(CoupleInt pos)
        {
            if (Charge > 0)
            {
                --Charge;
                List<AEntity> output = new List<AEntity>();
                for (int i = 0; i < Distance; i++)
                {
                    output.Add(new LaserBullet(new CoupleInt(pos.X + 1, pos.Y), new CoupleInt(1, 1), new CoupleInt(0, 0)));
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
