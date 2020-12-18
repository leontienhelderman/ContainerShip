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
        List<Stack> stacks;

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
                new Container(Container.type.coolable, 8000),
                new Container(Container.type.coolable, 17000),
                new Container(Container.type.coolable, 4000),
                new Container(Container.type.coolable, 15000),
            };

            stacks = new List<Stack>();
            var stack = new Stack();
            var stack1 = new Stack();
            var stack2 = new Stack();
            var stack3 = new Stack();
            var stack4 = new Stack();

            stack.AddContainerToStack(new Container(Container.type.coolable, 30000));
            stack1.AddContainerToStack(new Container(Container.type.coolable, 26000));
            stack2.AddContainerToStack(new Container(Container.type.coolable, 25000));
            stack3.AddContainerToStack(new Container(Container.type.coolable, 17000));
            stack4.AddContainerToStack(new Container(Container.type.coolable, 15000));
            stack4.AddContainerToStack(new Container(Container.type.coolable, 10000));
            stack3.AddContainerToStack(new Container(Container.type.coolable, 8000));
            stack2.AddContainerToStack(new Container(Container.type.coolable, 5000));
            stack3.AddContainerToStack(new Container(Container.type.coolable, 4000));

            stacks.Add(stack);
            stacks.Add(stack1);
            stacks.Add(stack2);
            stacks.Add(stack3);
            stacks.Add(stack4);
            
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

            //Assert
            CollectionAssert.AreEqual(stacks, row.DistributeContainers(containers));
        }
    }
}
