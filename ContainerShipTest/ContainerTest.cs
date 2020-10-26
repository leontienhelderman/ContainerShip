using ContainerShipLib;
using NUnit.Framework;
using System;

namespace ContainerShipTest
{
    public class ContainerTest
    {
        [TestCase(Container.type.coolable, Container.MinWeight)]
        [TestCase(Container.type.coolable, Container.MaxWeight)]
        [TestCase(Container.type.coolable, 15000)]
        public void CreateContainer_CorrectInput(Container.type type, int weight)
        {
            Container container = new Container(type, weight);

            Assert.NotNull(container);
            Assert.AreEqual(type, container.ContainerType);
            Assert.AreEqual(weight, container.ContainerWeight);
        }

        [TestCase(Container.type.valuable, Container.MinWeight - 1)]
        [TestCase(Container.type.coolable, Container.MaxWeight + 1)]
        [TestCase(Container.type.coolable, Int32.MaxValue)]
        [TestCase(Container.type.coolable, Int32.MinValue)]
        public void CreateContainer_InvalidWeight(Container.type type, int weight)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Container(type, weight));
        }
    }
}