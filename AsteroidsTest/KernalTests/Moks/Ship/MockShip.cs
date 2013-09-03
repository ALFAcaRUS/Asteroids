﻿using System.Collections.Generic;
using Game;
using Game.Entitys;
using Game.Ships;
using Game.Weapons;

namespace AsteroidsTest.KernalTests.Moks.Ship
{
    internal class MockShip : IShip
    {
        public CoupleInt Pos { get; set; }
        public List<IWeapon> Weapons { get; private set; }

        public List<AEntity> Shoot(int weaponNum)
        {
            return null;
        }
    }
}