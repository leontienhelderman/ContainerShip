using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerShipLib
{
    public class Row
    {
        Ship ship = new Ship(10, 120000, 5);
        private List<Stack> row;
        public Row()
        {
            row = new List<Stack>();
        }

        public List<Stack> FullRow(Stack stack)
        {
            for(int i =0; i <= ship.Width; i++)
            {
                Stack stack = new Stack();
                row.Add(stack);
            }

            //foreach(Stack stack in row)
            //{
            //    stack.AddContainerToStack(Container container);
            //}
            return row;
        }

        
    }
}
