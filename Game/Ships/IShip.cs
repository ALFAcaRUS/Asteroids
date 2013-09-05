using System.Collections.Generic;
using Game.Weapons;

namespace Game.Ships
{
    internal interface IShip
    {
        CoupleDouble Pos { get; set; }
        CoupleDouble Size { get; set; }
        Degree Direction { get; set; }
        List<IWeapon> Weapons {get; }


        void AddWeapon(IWeapon newWeapon);
    }
}
