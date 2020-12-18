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

        public List<Stack> DistributeContainers(List<Container> containers)
        {
            return AddCoolablesToStackWithLowestWeight(containers);

            

        }

        private IEnumerable<Container> GetCoolables(List<Container> containers)
        {
            var coolablecontainers = containers.Where(c => c.ContainerType == Container.type.coolable);
            return coolablecontainers;
        }

        private Stack GetStackWithLowestWeight()
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
                return selectedStack;
            }

            return null;
        }

        private void AddCoolablesToStackWithLowestWeight(List<Container> containers)
        {
            
            foreach (Container container in GetCoolables(containers))
            {

                if (GetStackWithLowestWeight() != null)
                {
                    GetStackWithLowestWeight().AddContainerToStack(container);
                }

            }
        }

    }
}
