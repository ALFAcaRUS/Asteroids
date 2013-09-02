using System;
using Game.Support;
using Game.Entitys.Enemies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsteroidsTest.KernalTests.EntitysTest.EnemisTests
{
    [TestClass]
    public class AsteroidTest
    {
        

        [TestMethod]
        public void MovingTest()
        {
            Asteroid asteroid = new Asteroid(new Point(1,1), new Size(1,1));

        }
    }
}
