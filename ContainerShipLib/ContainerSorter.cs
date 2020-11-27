using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContainerShipLib
{
    public class ContainerSorter
    {
        private List<Container> containers;

        public ContainerSorter()
        {
            containers = new List<Container>();
        }

        public List<Container> SortContainers(List<Container> containers)
        {
            OrderContainersByWeight(containers);

            return containers;
        }

        private List<Container> SortContainersByType(List<Container> containers)
        {
            containers.OrderBy(c => (int)c.ContainerType).ToList();
            return containers;
        }

        private List<Container> OrderContainersByWeight(List<Container> containers)
        {
            return containers.OrderBy(c => c.ContainerWeight).ToList();
        }
    }
}
