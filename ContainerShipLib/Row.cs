using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContainerShipLib
{
    public class Row
    {
        public int Width { get; }
        private List<Stack> stacks;
        public IReadOnlyCollection<Stack> Stacks { get { return stacks.AsReadOnly();} }

        public Row(int width)
        {
            Width = width;
            stacks = new List<Stack>();
            CreateStacks();
        }

        private void CreateStacks()
        {
            for(int i =0; i < Width; i++)
            {
                Stack stack = new Stack();
                stacks.Add(stack);
            }
        }
    }
}
