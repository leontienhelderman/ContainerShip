using ContainerShipLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipTest
{
    public class RowTest
    {
        private Row row;
        [SetUp]
        public void SetUp()
        {
            row = new Row(5);
        }

        [Test]
        public void CreateStacks_ReturnsCorrectAmountOfStacks()
        {
            Assert.AreEqual(5, row.Stacks.Count);
        }
    }
}
