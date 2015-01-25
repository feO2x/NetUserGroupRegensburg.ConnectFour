using System;

namespace ConnectFour.Core
{
    public class Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            if (x < 0)
                throw new ArgumentException("x cannot be less than zero.");
            if (y < 0)
                throw new ArgumentException("y cannot be less than zero.");

            X = x;
            Y = y;
        }

        public Chip Chip { get; set; }
    }
}