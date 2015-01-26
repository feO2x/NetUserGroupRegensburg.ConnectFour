using ConnectFour.Core;
using System;

namespace ConnectFour.WpfClient
{
    public class CellPropertyChangedDecorator : BaseViewModel, ICell
    {
        private readonly ICell _cell;

        public CellPropertyChangedDecorator(ICell cell)
        {
            if (cell == null) throw new ArgumentNullException("cell");

            _cell = cell;
        }

        public Chip Chip
        {
            get { return _cell.Chip; }
            set
            {
                if (value == _cell.Chip)
                    return;

                _cell.Chip = value;
                OnPropertyChanged();
            }
        }

        public int X
        {
            get { return _cell.X; }
        }

        public int Y
        {
            get { return _cell.Y; }
        }
    }
}