using System.Collections.Generic;
using Game.Entitys;

namespace Game.Weapons
{
    internal interface IWeapon
    {
        List<AEntity> Shot(CoupleDouble pos, Degree direction);

        void Update();
    }
}
