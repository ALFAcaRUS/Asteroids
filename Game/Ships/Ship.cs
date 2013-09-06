using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Entitys;
using Game.Weapons;

namespace Game.Ships
{
    class Ship:IShip
    {
        public CoupleDouble Pos { get; set; }
        public CoupleDouble Size { get; set; }
        public Degree Direction { get; set; }
        public List<IWeapon> Weapons { get; set; }

        public Ship()
        {
            Pos = new CoupleDouble(0, 0);
            Weapons = new List<IWeapon>();
            Size = CoupleDouble.ones;
            Direction = new Degree();
        }

        public void AddWeapon(IWeapon newWeapon)
        {
            Weapons.Add(newWeapon);
        }
    }
}
