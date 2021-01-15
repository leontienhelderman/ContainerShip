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
        public IReadOnlyCollection<Container> Containers { get { return stack.AsReadOnly(); } }

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
            //stack = OrderStackByWeight(stack);
            

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

        public int GetWeight()
        {
            return stack.Sum(c => c.ContainerWeight);
        }

        public override string ToString()
        {
            string result = "";
            foreach(Container container in stack)
            {
                result += container.ToString();
            }
            return result;
        }
    }
}
