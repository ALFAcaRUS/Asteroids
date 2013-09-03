using System.Collections.Generic;
using Game.Weapons;

namespace Game.Ships
{
    internal interface IShip
    {
        CoupleInt Pos { get; set; }
        List<IWeapon> Weapons {get; }

        void AddWeapon(IWeapon newWeapon);
    }
}
