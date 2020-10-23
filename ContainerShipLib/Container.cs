using System;

namespace ContainerShipLib
{
    public class Container
    {
        public type ContainerType { get; private set; }
        public weight ContainerWeight { get; private set; }

        public Container(type type, weight weight)
        {
            ContainerType = type;
            ContainerWeight = weight;
        }

        public enum type
        {
            normal,
            valuable,
            coolable,
            valuecool
        }

        public enum weight
        {
            empty = 4,
            full = 3000
        }
    }
}
