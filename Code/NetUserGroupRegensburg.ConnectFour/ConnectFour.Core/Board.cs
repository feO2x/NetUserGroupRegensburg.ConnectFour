using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Board
    {
        public readonly IReadOnlyList<Cell> Cells;
        public readonly IReadOnlyList<BoardLine> BoardLines;

        public Board(IReadOnlyList<Cell> cells,
                     IReadOnlyList<BoardLine> boardLines)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            if (boardLines == null) throw new ArgumentNullException("boardLines");

            Cells = cells;
            BoardLines = boardLines;
        }

        public string DetermineWinner()
        {
// ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var boardLine in BoardLines)
            {
                var winner = boardLine.DetermineIfPlayerHasFourInALine();
                if (winner != null)
                    return winner;
            }
            return null;
        }
    }
}
