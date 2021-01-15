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
            var stacks = new List<Stack>();
            var coolables = AddCoolablesToStackWithLowestWeight(containers);
            var normals = AddNormalsToStackWithLowestWeight(containers);
            stacks.AddRange(coolables);
            stacks.AddRange(normals);

            return stacks;

        }

        private IEnumerable<Container> GetCoolables(List<Container> containers)
        {
            var coolableContainers = containers.Where(c => c.ContainerType == Container.type.coolable);
            return coolableContainers.OrderByDescending(c => c.ContainerWeight).ToList();
        }

        private IEnumerable<Container> GetNormals(List<Container> containers)
        {
            var normalContainers = containers.Where(c => c.ContainerType == Container.type.normal);
            return normalContainers.OrderByDescending(c => c.ContainerWeight).ToList();
        }

        private IEnumerable<Container> GetValuables(List<Container> containers)
        {
            var valuableContainers = containers.Where(c => c.ContainerType == Container.type.valuable);
            return valuableContainers.OrderByDescending(c => c.ContainerWeight).ToList();
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

        public List<Stack> AddCoolablesToStackWithLowestWeight(List<Container> containers)
        {
            HashSet<Stack> stacks = new HashSet<Stack>();
            
            foreach (Container container in GetCoolables(containers))
            {
                var stack = GetStackWithLowestWeight();
                if (stack != null)
                {
                    stack.AddContainerToStack(container);
                    stacks.Add(stack);
                }

            }
            return stacks.ToList();
        }

        public List<Stack> AddNormalsToStackWithLowestWeight(List<Container> containers)
        {
            HashSet<Stack> stacks = new HashSet<Stack>();

            foreach(Container container in GetNormals(containers))
            {
                var stack = GetStackWithLowestWeight();
                if(stack != null)
                {
                    stack.AddContainerToStack(container);
                    stacks.Add(stack);
                }
            }
            return stacks.ToList();
        }

    }
}
