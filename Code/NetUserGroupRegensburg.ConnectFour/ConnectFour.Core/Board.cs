using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Board
    {
        public readonly IReadOnlyList<Cell> Cells;
        public readonly IReadOnlyList<BoardLine> BoardLines;
        public readonly IReadOnlyList<Column> Columns;
        public readonly IReadOnlyList<Row> Rows;
        public readonly IReadOnlyList<Diagonal> Diagonals;

        public Board(IReadOnlyList<Cell> cells,
                     IReadOnlyList<BoardLine> boardLines,
                     IReadOnlyList<Column> columns,
                     IReadOnlyList<Row> rows,
                     IReadOnlyList<Diagonal> diagonals)
        {
            if (cells == null) throw new ArgumentNullException("cells");
            if (boardLines == null) throw new ArgumentNullException("boardLines");
            if (columns == null) throw new ArgumentNullException("columns");
            if (rows == null) throw new ArgumentNullException("rows");
            if (diagonals == null) throw new ArgumentNullException("diagonals");

            Cells = cells;
            BoardLines = boardLines;
            Columns = columns;
            Rows = rows;
            Diagonals = diagonals;
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
