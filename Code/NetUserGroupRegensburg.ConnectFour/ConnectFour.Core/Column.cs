using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.Core
{
    public class Column : BoardLine, IColumn
    {
        public readonly int Index;

        public Column(int index, IReadOnlyList<Cell> cells)
            : base(cells)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be less than 0", "index");

            Index = index;
        }

        public void SetChip(Chip chip)
        {
            if (chip == null) throw new ArgumentNullException("chip");

            foreach (var cell in Cells)
            {
                if (cell.Chip == null)
                {
                    cell.Chip = chip;
                    return;
                }
            }

            throw new InvalidOperationException("You cannot set a chip when all cells in this column already have a chip.");
        }

        public bool IsFull
        {
            get { return Cells.All(cell => cell.Chip != null); }
        }
    }
}
