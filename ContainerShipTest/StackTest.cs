using ContainerShipLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipTest
{
    public class StackTest
    {
        private Stack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new Stack();
            stack.AddContainerToStack(new Container(Container.type.normal, 25000));
            stack.AddContainerToStack(new Container(Container.type.normal, 30000));
            stack.AddContainerToStack(new Container(Container.type.normal, 20000));
            stack.AddContainerToStack(new Container(Container.type.normal, 15000));
            stack.AddContainerToStack(new Container(Container.type.normal, 26000));

            //add this container so the sum of the other containers weight will be 116000 this container will be removed from the list to do the sum
            stack.AddContainerToStack(new Container(Container.type.normal, 30000));
        }

        [Test]
        public void AddContainerToStack_ReturnsTrue()
        {
            var stack = new Stack();
            Assert.IsTrue(stack.AddContainerToStack(new Container(Container.type.normal, 15300)));
        }

        [Test]
        public void AddContainerToStack_ExceedStackWeightCapacity_returnsFalse()
        {
            Assert.IsFalse(stack.AddContainerToStack(new Container(Container.type.normal, 4001)));
        }

        [Test]
        public void AddContainerToStack_FitsPerfectly_returnsTrue()
        {
            Assert.IsTrue(stack.AddContainerToStack(new Container(Container.type.normal, 4000)));
        }
    }
}
