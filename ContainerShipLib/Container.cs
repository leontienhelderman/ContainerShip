using System;

namespace ContainerShipLib
{
    public class Container
    {
        public const int MinWeight = 4000;
        public const int MaxWeight = 30000;
        public type ContainerType { get; private set; }
        public int ContainerWeight { get; private set; }

        public Container(type type, int weight)
        {
            ContainerType = type;
            if(weight >= MinWeight && weight <= MaxWeight)
            {
                ContainerWeight = weight;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Weight is invalid");
            }
            
        }

        public enum type
        {
            coolable,
            normal,
            valuable
        }

    }
}
