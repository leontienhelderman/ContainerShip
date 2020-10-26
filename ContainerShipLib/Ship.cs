using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipLib
{
    class Ship
    {
        private List<Container> _containers;

        public Ship()
        {

            _containers = new List<Container>()
            {
                new Container(Container.type.coolable, 5000),
                new Container(Container.type.valuable, 4500),
                new Container(Container.type.coolable, 29999),
                new Container(Container.type.normal, 15300),
                new Container(Container.type.normal, 25550),
                new Container(Container.type.valuecool, 30000),
                new Container(Container.type.valuecool, 4000),
                new Container(Container.type.coolable, 12500),
                new Container(Container.type.valuable, 6500),
                new Container(Container.type.valuable, 4000),
            };
        }

        public int CapacityStack
        {
            get {
                int sum = 0;

                foreach (Container container in _containers)
                {
                    sum += (int)container.ContainerWeight;
                }

                return 120 - sum;
            }

        }
    }
}
