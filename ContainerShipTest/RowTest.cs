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
        List<Container> containers;

        [SetUp]
        public void SetUp()
        {
            row = new Row(5);
            containers = new List<Container>()
            {
                new Container(Container.type.coolable, 5000),
                new Container(Container.type.coolable, 30000),
                new Container(Container.type.coolable, 25000),
                new Container(Container.type.coolable, 26000),
                new Container(Container.type.coolable, 10000),
                new Container(Container.type.coolable, 80000),
                new Container(Container.type.coolable, 17000),
                new Container(Container.type.coolable, 4000),
                new Container(Container.type.coolable, 15000),
            };
        }

        [Test]
        public void CreateStacks_ReturnsCorrectAmountOfStacks()
        {
            Assert.AreEqual(5, row.Stacks.Count);
        }

        [Test]
        public void DistributeContainers_FillsStacksCorrectly()
        {
            //Assign

            //Act
            row.DistributeContainers(containers);

            //Assert
            CollectionAssert.;
        }
    }
}
