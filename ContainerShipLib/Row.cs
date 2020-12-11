using System.Collections.Generic;
using System.Linq;

namespace ContainerShipLib
{
    public class Row
    {
        public int Width { get; }
        private List<Stack> stacks;
        public IReadOnlyCollection<Stack> Stacks { get { return stacks.AsReadOnly(); } }

        public Row(int width)
        {
            Width = width;
            stacks = new List<Stack>();
            CreateStacks();
        }

        private void CreateStacks()
        {
            for (int i = 0; i < Width; i++)
            {
                Stack stack = new Stack();
                stacks.Add(stack);
            }
        }

        public void DistributeContainers(List<Container> containers)
        {
            var coolablecontainers = containers.Where(c => c.ContainerType == Container.type.coolable);

            foreach (Container container in coolablecontainers)
            {
                Stack selectedStack = null;
                int lowestWeight = int.MaxValue;

                foreach (Stack stack in Stacks)
                {
                    if (stack.GetWeight() < lowestWeight)
                    {
                        selectedStack = stack;
                        lowestWeight = stack.GetWeight();
                    }

                }

                if (selectedStack != null)
                {
                    selectedStack.AddContainerToStack(container);
                }

            }

        }

    }
}
