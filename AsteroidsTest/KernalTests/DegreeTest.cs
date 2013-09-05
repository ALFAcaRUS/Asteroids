using System;
using Game;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsteroidsTest.KernalTests
{
    [TestClass]
    public class DegreeTest
    {
        [TestMethod]
        public void NormalValueTest()
        {
            Degree testedDegree = new Degree();

            testedDegree.Angle = 180;

            Assert.AreEqual(180, testedDegree.Angle);
            Assert.AreEqual(Math.PI, testedDegree.ToRadian());

        }

        [TestMethod]
        public void ToHighValue()
        {
            Degree first = new Degree();
            Degree second = new Degree(540);

            first.Angle = 540;

            Assert.AreEqual(180, first.Angle);
            Assert.AreEqual(180, second.Angle);

            first.SetProjections(new CoupleDouble(-1, 0));

            Assert.AreEqual(180, first.Angle);
        }

    }
}
