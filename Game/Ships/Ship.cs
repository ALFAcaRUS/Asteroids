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
        public CoupleInt Pos { get; set; }
        public List<IWeapon> Weapons { get; private set; }

        public Ship()
        {
            Pos = new CoupleInt(0, 0);
            Weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon newWeapon)
        {
            Weapons.Add(newWeapon);
        }
    }
}
