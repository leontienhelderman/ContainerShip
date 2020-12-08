using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipLib
{
    public class Ship
    {
        public int Length { get; }
        public int Width { get; }
        public int Weight { get; }
        private List<Row> rows;
        public IReadOnlyCollection<Row> Rows { get { return rows.AsReadOnly(); } }

        public Ship(int length, int width, int weight)
        {
            Length = length;
            Weight = weight;
            Width = width;
            rows = new List<Row>();
            CreateRows();
        }

        private void CreateRows()
        {
            for(int i =0; i< Length; i++)
            {
                Row row = new Row(Width);
                rows.Add(row);
            }
        }
    }
}
