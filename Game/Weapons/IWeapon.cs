using System.Collections.Generic;
using Game.Entitys;

namespace Game.Weapons
{
    interface IWeapon
    {
        List<AEntity> Shot(CoupleInt pos);
    }
}
