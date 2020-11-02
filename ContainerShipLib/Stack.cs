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

        private int WeightCapacity = 120000;
        public Stack()
        {
            stack = new List<Container>();

        }

        public bool AddContainerToStack(Container _container)
        {
            if (!StackWeightFit(_container))
            {
                return false;
            }

            stack.Add(_container);
            stack = OrderStackByWeight(stack);
            

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

        private void OrderByContainerType(List<Container> containers)
        {
            List<Container> coolablecontainers = new List<Container>();
            List<Container> valuablecontainers = new List<Container>();
            List<Container> valuecoolcontainers = new List<Container>();
            List<Container> normalcontainers = new List<Container>();

            foreach (Container container in containers)
            {
                if (container.ContainerType == Container.type.coolable)
                {
                    coolablecontainers.Add(container);
                }
                else if (container.ContainerType == Container.type.valuable)
                {
                    valuablecontainers.Add(container);
                }
                else if (container.ContainerType == Container.type.valuecool)
                {
                    valuecoolcontainers.Add(container);
                }
                else if (container.ContainerType == Container.type.normal)
                {
                    normalcontainers.Add(container);
                }
            }

            coolablecontainers = OrderStackByWeight(coolablecontainers);
            valuablecontainers = OrderStackByWeight(valuablecontainers);
            valuecoolcontainers = OrderStackByWeight(valuecoolcontainers);
            normalcontainers = OrderStackByWeight(normalcontainers);
        }

        public List<Container> OrderStackByWeight(List<Container> containers)
        {
            return containers.OrderBy(c => c.ContainerWeight).ToList();
        }

    }
}
