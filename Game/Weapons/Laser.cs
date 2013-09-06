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
        public double Charge { get; set; }
        public int Distance { get; set; }

        private double _maxCharge = 10;

        public Laser()
        {
            Charge = 100;
            Distance = 100;
        }

        public List<AEntity> Shot(CoupleDouble pos, Degree direction)
        {
            if (Charge > 1)
            {
                --Charge;
                List<AEntity> output = new List<AEntity>();
                CoupleDouble positions = new CoupleDouble(pos.X, pos.Y);

                for (int i = 0; i < Distance; i++)
                {
                    positions = positions + direction.GetProjections();
                    output.Add(new LaserBullet(positions, CoupleDouble.ones, CoupleDouble.zero));
                }

                return output.Count != 0 ? output : null;
            }
            else
            {
                return null;
            }
        }

        public void Update()
        {
            if (Charge < _maxCharge)
            {
                Charge += 0.05;
            }
        }
    }
}
