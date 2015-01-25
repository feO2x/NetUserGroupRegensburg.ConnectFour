using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour.Core
{
    public class Column
    {
        private readonly IReadOnlyList<Cell> _cells;

        public Column(IReadOnlyList<Cell> cells)
        {
            if (cells == null) throw new ArgumentNullException("cells");

            _cells = cells;
        }

        public void SetChip(Chip chip)
        {
            if (chip == null) throw new ArgumentNullException("chip");

            foreach (var cell in _cells)
            {
                if (cell.Chip == null)
                {
                    cell.Chip = chip;
                    return;
                }
            }

            throw new InvalidOperationException("You cannot set a chip when all cells in this column already have a chip.");
        }

        public bool IsColumnFull
        {
            get { return _cells.All(cell => cell.Chip != null); }
        }
    }
}
