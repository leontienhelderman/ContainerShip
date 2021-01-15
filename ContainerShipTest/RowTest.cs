using ContainerShipLib;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerShipTest
{
    public class RowTest
    {
        private Row row;
        List<Container> containers;
        List<Stack> controlStacks;

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

        //[Test]
        //public void DistributeContainers_ReturnsCorrectStacks()
        //{
        //    //Assign
        //    containers = new List<Container>();
        //    var container = new Container(Container.type.coolable, 5000);
        //    var container1 = new Container(Container.type.coolable, 30000);
        //    var container2 = new Container(Container.type.coolable, 25000);
        //    var container3 = new Container(Container.type.coolable, 26000);
        //    var container4 = new Container(Container.type.coolable, 10000);
        //    var container5 = new Container(Container.type.coolable, 8000);
        //    var container6 = new Container(Container.type.coolable, 17000);
        //    var container7 = new Container(Container.type.coolable, 4000);
        //    var container8 = new Container(Container.type.coolable, 15000);
        //    var container9 = new Container(Container.type.normal, 30000);
        //    var container10 = new Container(Container.type.normal, 6000);
        //    var container11 = new Container(Container.type.normal, 14000);
        //    var container12 = new Container(Container.type.normal, 19000);

        //    containers.Add(container);
        //    containers.Add(container1);
        //    containers.Add(container2);
        //    containers.Add(container3);
        //    containers.Add(container4);
        //    containers.Add(container5);
        //    containers.Add(container6);
        //    containers.Add(container7);
        //    containers.Add(container8);
        //    containers.Add(container9);
        //    containers.Add(container10);
        //    containers.Add(container11);
        //    containers.Add(container12);

        //    controlStacks = new List<Stack>();

        //    for (int i = 0; i < 5; i++)
        //    {
        //        Stack stack = new Stack();

        //        switch (i)
        //        {
        //            case 0:
        //                stack.AddContainerToStack(containers[1]);
        //                break;
        //            case 1:
        //                stack.AddContainerToStack(containers[3]);
        //                break;
        //            case 2:
        //                stack.AddContainerToStack(containers[2]);
        //                stack.AddContainerToStack(containers[0]);
        //                break;
        //            case 3:
        //                stack.AddContainerToStack(containers[6]);
        //                stack.AddContainerToStack(containers[5]);
        //                stack.AddContainerToStack(containers[7]);
        //                break;
        //            case 4:
        //                stack.AddContainerToStack(containers[8]);
        //                stack.AddContainerToStack(containers[4]);
        //                break;
        //            default:
        //                break;
        //        }

        //        controlStacks.Add(stack);

        //    }

        //    //Act
        //    List<Stack> testStack = row.DistributeContainers(containers);

        //    //Assert
        //    for (int stackId = 0; stackId < testStack.Count(); stackId++)
        //    {
        //        for (int containerId = 0; containerId < testStack[stackId].Containers.Count(); containerId++)
        //        {
        //            Assert.AreEqual(controlStacks[stackId].Containers.ElementAt(containerId).ContainerWeight, testStack[stackId].Containers.ElementAt(containerId).ContainerWeight);
        //        }
        //    }
        //}

        [Test]
        public void AddCoolableContainersToStackwithLowestWeight_FillsStacksCorrectly()
        {
            //Assign
            containers = new List<Container>();
            var container = new Container(Container.type.coolable, 5000);
            var container1 = new Container(Container.type.coolable, 30000);
            var container2 = new Container(Container.type.coolable, 25000);
            var container3 = new Container(Container.type.coolable, 26000);
            var container4 = new Container(Container.type.coolable, 10000);
            var container5 = new Container(Container.type.coolable, 8000);
            var container6 = new Container(Container.type.coolable, 17000);
            var container7 = new Container(Container.type.coolable, 4000);
            var container8 = new Container(Container.type.coolable, 15000);

            containers.Add(container);
            containers.Add(container1);
            containers.Add(container2);
            containers.Add(container3);
            containers.Add(container4);
            containers.Add(container5);
            containers.Add(container6);
            containers.Add(container7);
            containers.Add(container8);
            

            controlStacks = new List<Stack>();

            for (int i = 0; i < 5; i++)
            {
                Stack stack = new Stack();

                switch (i)
                {
                    case 0:
                        stack.AddContainerToStack(containers[1]);
                        break;
                    case 1:
                        stack.AddContainerToStack(containers[3]);
                        break;
                    case 2:
                        stack.AddContainerToStack(containers[2]);
                        stack.AddContainerToStack(containers[0]);
                        break;
                    case 3:
                        stack.AddContainerToStack(containers[6]);
                        stack.AddContainerToStack(containers[5]);
                        stack.AddContainerToStack(containers[7]);
                        break;
                    case 4:
                        stack.AddContainerToStack(containers[8]);
                        stack.AddContainerToStack(containers[4]);
                        break;
                    default:
                        break;
                }

                controlStacks.Add(stack);
            }

            //Act
            List<Stack> testStack = row.AddCoolablesToStackWithLowestWeight(containers);

            //Assert
            for(int stackId = 0; stackId < testStack.Count(); stackId++)
            {
                for(int containerId = 0; containerId < testStack[stackId].Containers.Count(); containerId++)
                {
                    Assert.AreEqual(controlStacks[stackId].Containers.ElementAt(containerId).ContainerWeight, testStack[stackId].Containers.ElementAt(containerId).ContainerWeight);
                }
            }
            

        }

        [Test]
        public void AddCoolableContainersToStackwithLowestWeight_HasANonCoolableThatDoesNotGetAddedToStack()
        {
            //Assign
            containers = new List<Container>();
            var container = new Container(Container.type.coolable, 5000);
            var container1 = new Container(Container.type.coolable, 30000);
            var container2 = new Container(Container.type.coolable, 25000);
            var container3 = new Container(Container.type.coolable, 26000);
            var container4 = new Container(Container.type.valuable, 10000);
            var container5 = new Container(Container.type.coolable, 8000);
            var container6 = new Container(Container.type.coolable, 17000);
            var container7 = new Container(Container.type.normal, 4000);
            var container8 = new Container(Container.type.coolable, 15000);

            containers.Add(container);
            containers.Add(container1);
            containers.Add(container2);
            containers.Add(container3);
            containers.Add(container4);
            containers.Add(container5);
            containers.Add(container6);
            containers.Add(container7);
            containers.Add(container8);

            controlStacks = new List<Stack>();

            for (int i = 0; i < 5; i++)
            {
                Stack stack = new Stack();

                switch (i)
                {
                    case 0:
                        stack.AddContainerToStack(containers[1]);
                        break;
                    case 1:
                        stack.AddContainerToStack(containers[3]);
                        break;
                    case 2:
                        stack.AddContainerToStack(containers[2]);
                        
                        break;
                    case 3:
                        stack.AddContainerToStack(containers[6]);
                        stack.AddContainerToStack(containers[0]);
                        break;
                    case 4:
                        stack.AddContainerToStack(containers[8]);
                        stack.AddContainerToStack(containers[5]);
                        break;
                    default:
                        break;
                }

                controlStacks.Add(stack);
            }

            //Act
            List<Stack> testStack = row.AddCoolablesToStackWithLowestWeight(containers);

            //Assert
            for (int stackId = 0; stackId < testStack.Count(); stackId++)
            {
                for (int containerId = 0; containerId < testStack[stackId].Containers.Count(); containerId++)
                {
                    Assert.AreEqual(controlStacks[stackId].Containers.ElementAt(containerId).ContainerWeight, testStack[stackId].Containers.ElementAt(containerId).ContainerWeight);
                }
            }

        }


        [Test]
        public void AddNormalContainersToStackWithLowestWeight_FillsStacksCorrectly()
        {
            //Assign
            containers = new List<Container>();
            var container = new Container(Container.type.normal, 5000);
            var container1 = new Container(Container.type.normal, 30000);
            var container2 = new Container(Container.type.normal, 25000);
            var container3 = new Container(Container.type.normal, 26000);
            var container4 = new Container(Container.type.normal, 10000);
            var container5 = new Container(Container.type.normal, 8000);
            var container6 = new Container(Container.type.normal, 17000);
            var container7 = new Container(Container.type.normal, 4000);
            var container8 = new Container(Container.type.normal, 15000);

            containers.Add(container);
            containers.Add(container1);
            containers.Add(container2);
            containers.Add(container3);
            containers.Add(container4);
            containers.Add(container5);
            containers.Add(container6);
            containers.Add(container7);
            containers.Add(container8);


            controlStacks = new List<Stack>();

            for (int i = 0; i < 5; i++)
            {
                Stack stack = new Stack();

                switch (i)
                {
                    case 0:
                        stack.AddContainerToStack(containers[1]);
                        break;
                    case 1:
                        stack.AddContainerToStack(containers[3]);
                        break;
                    case 2:
                        stack.AddContainerToStack(containers[2]);
                        stack.AddContainerToStack(containers[0]);
                        break;
                    case 3:
                        stack.AddContainerToStack(containers[6]);
                        stack.AddContainerToStack(containers[5]);
                        stack.AddContainerToStack(containers[7]);
                        break;
                    case 4:
                        stack.AddContainerToStack(containers[8]);
                        stack.AddContainerToStack(containers[4]);
                        break;
                    default:
                        break;
                }

                controlStacks.Add(stack);
            }
            //Act
            List<Stack> testStack = row.AddNormalsToStackWithLowestWeight(containers);

            //Assert
            for (int stackId = 0; stackId < testStack.Count(); stackId++)
            {
                for (int containerId = 0; containerId < testStack[stackId].Containers.Count(); containerId++)
                {
                    Assert.AreEqual(controlStacks[stackId].Containers.ElementAt(containerId).ContainerWeight, testStack[stackId].Containers.ElementAt(containerId).ContainerWeight);
                }
            }

        }
    }
}
