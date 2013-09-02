using System.Collections.Generic;
using Game.Weapons;
using Game.Entitys;

namespace Game.Ships
{
    internal interface IShip
    {
        CoupleInt Pos { get; set; }
        List<IWeapon> Weapons {get; }

        List<AEntity> Shoot(int weaponNum);
    }
}
