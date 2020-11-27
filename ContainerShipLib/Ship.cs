using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipLib
{
    public class Ship
    {
        public int Length { get; }
        public int Weight { get; }
        public int Width { get; }
        private List<Row> ship;
        public Ship(int length, int weight, int width)
        {
            Length = length;
            Weight = weight;
            Width = width;
            ship = new List<Row>();
        }

        public List<Row> FullShip(Row row)
        {
            ship.Add(row);
            return ship;
        }
    }
}
