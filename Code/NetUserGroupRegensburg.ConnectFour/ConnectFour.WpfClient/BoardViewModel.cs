using ConnectFour.Core;
using System;
using System.Collections.Generic;

namespace ConnectFour.WpfClient
{
    public class BoardViewModel : IBoardViewModel
    {
        private readonly IReadOnlyList<ICell> _cells;
        private readonly IReadOnlyCollection<IClickColumnCommand> _clickColumnCommands;

        public BoardViewModel(IReadOnlyList<ICell> cells, IReadOnlyCollection<IClickColumnCommand> clickColumnCommands)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            if (clickColumnCommands == null) throw new ArgumentNullException("clickColumnCommands");

            _cells = cells;
            _clickColumnCommands = clickColumnCommands;
        }

        public IReadOnlyList<ICell> Cells
        {
            get { return _cells; }
        }

        public IReadOnlyCollection<IClickColumnCommand> ClickColumnCommands
        {
            get { return _clickColumnCommands; }
        }
    }
}
