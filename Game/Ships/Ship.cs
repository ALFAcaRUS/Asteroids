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

        public void AddWeapon(IWeapon newWeapon)
        {
            throw new NotImplementedException();
        }
    }
}
