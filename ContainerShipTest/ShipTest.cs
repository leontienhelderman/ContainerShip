using ContainerShipLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipTest
{
    public class ShipTest
    {
        private Ship ship;

        [SetUp]
        public void SetUp()
        {
            ship = new Ship(5, 5, 12000);
        }

        [Test]
        public void CreateRow_ReturnsCorrectAmountOfRows()
        {
            Assert.AreEqual(5, ship.Rows.Count);
        }
    }
}
