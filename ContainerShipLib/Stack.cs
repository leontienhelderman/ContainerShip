using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ContainerShipLib
{
    public class Stack
    {
        private List<Container> stack;
        Ship ship;
        private int WeightCapacity = 120000;
        public Stack()
        {
            stack = new List<Container>();
            ship = new Ship(10, 120000, 5);
        }

        public bool AddContainerToStack(Container _container)
        {
            if (!StackWeightFit(_container))
            {
                return false;
            }
            
            for(int i = 0; i <= ship.Width; i++)
            {
                Stack s = new Stack();
                if(_container.ContainerType == Container.type.coolable)
                {
                    stack.Add(_container);
                }
            }

            stack = OrderStackByWeight(stack);
            if(_container.ContainerType == Container.type.coolable)
            {
                stack.Add(_container);
            }

            return true;
        }

        private bool StackWeightFit(Container container)
        {
            List<Container> tempList = new List<Container>();
            tempList.AddRange(stack);
            tempList.Add(container);
            tempList = OrderStackByWeight(tempList);

            var bottomContainer = tempList.Remove(tempList.Last());

            var tempList2 = tempList;

            int sum = 0;
            foreach (Container container1 in tempList2)
            {
                sum += container1.ContainerWeight;
            }

            if (sum <= WeightCapacity)
            {
                return true;
            }
            return false;
        }

        private List<Container> OrderStackByWeight(List<Container> containers)
        {
            return containers.OrderBy(c => c.ContainerWeight).ToList();
        }

    }
}
