using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Game.Ships;
using Game.Weapons;
using AsteroidsTest.KernalTests.Moks.Weapons;

namespace AsteroidsTest.KernalTests.ShipsTests
{
    [TestClass]
    public class BasicShipTest
    {
        [TestMethod]
        public void WeaponTest()
        {
            Ship testedSpip = new Ship();

            testedSpip.AddWeapon(new MockWeapon());

            List<IWeapon> expected = new List<IWeapon>
            {
                new MockWeapon()
            };

            //Assert.AreEqual(expected, testedSpip.Weapons);

        }
    }
}
