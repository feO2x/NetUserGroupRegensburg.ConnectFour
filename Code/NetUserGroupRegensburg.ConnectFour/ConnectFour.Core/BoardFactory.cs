using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.Core
{
    public class BoardFactory
    {
        public Board CreateBoard(int numberOfColumns, int numberOfRows)
        {
            // Cell array
            var twoDimensionalCellArray = new Cell[numberOfColumns][];
            for (var x = 0; x < numberOfColumns; x++)
            {
                twoDimensionalCellArray[x] = new Cell[numberOfRows];
                for (var y = 0; y < numberOfRows; y++)
                {
                    twoDimensionalCellArray[x][y] = new Cell(x, y);
                }
            }

            // Columns
            var columns = new List<Column>();
            for (var i = 0; i < numberOfColumns; i++)
            {
                columns.Add(new Column(i, twoDimensionalCellArray[i]));
            }

            // Rows
            var rows = new List<Row>();
            for (var y = 0; y < numberOfRows; y++)
            {
                var rowCells = new List<Cell>();
                for (var x = 0; x < numberOfColumns; x++)
                {
                    rowCells.Add(twoDimensionalCellArray[x][y]);
                }
                rows.Add(new Row(y, rowCells));
            }

            // Diagonals
            // From top-left to bottom-right
            var diagonals = new List<Diagonal>();
            var diagonalDirection = DiagonalDirection.TopLeftToBottomRight;
            for (var x = 0; x < numberOfColumns; x++)
            {
                var columnIndex = x;
                var rowIndex = 0;

                var diagonalCells = new List<Cell>();
                while (columnIndex < numberOfColumns && rowIndex < numberOfRows)
                {
                    diagonalCells.Add(twoDimensionalCellArray[columnIndex][rowIndex]);
                    columnIndex++;
                    rowIndex++;
                }

                if (diagonalCells.Count >= 4)
                    diagonals.Add(new Diagonal(x, 0, diagonalDirection, diagonalCells));
            }

            for (var y = 0; y < numberOfRows; y++)
            {
                var columnIndex = 0;
                var rowIndex = y;

                var diagonalCells = new List<Cell>();
                while (columnIndex < numberOfColumns && rowIndex < numberOfRows)
                {
                    diagonalCells.Add(twoDimensionalCellArray[columnIndex][rowIndex]);
                    columnIndex++;
                    rowIndex++;
                }

                if (diagonalCells.Count >= 4)
                    diagonals.Add(new Diagonal(0, y, diagonalDirection, diagonalCells));
            }

            // From top-right to bottom-left
            diagonalDirection = DiagonalDirection.TopRightToBottomLeft;
            for (var x = 0; x < numberOfColumns; x++)
            {
                var columnIndex = x;
                var rowIndex = 0;

                var diagonalCells = new List<Cell>();
                while (columnIndex >= 0 && rowIndex < numberOfRows)
                {
                    diagonalCells.Add(twoDimensionalCellArray[columnIndex][rowIndex]);
                    columnIndex--;
                    rowIndex++;
                }

                if (diagonalCells.Count >= 4)
                    diagonals.Add(new Diagonal(x, 0, diagonalDirection, diagonalCells));
            }

            for (var y = 0; y < numberOfRows; y++)
            {
                var columnIndex = numberOfColumns - 1;
                var rowIndex = y;

                var diagonalCells = new List<Cell>();
                while (columnIndex >= 0 && rowIndex < numberOfRows)
                {
                    diagonalCells.Add(twoDimensionalCellArray[columnIndex][rowIndex]);
                    columnIndex--;
                    rowIndex++;
                }

                if (diagonalCells.Count >= 4)
                    diagonals.Add(new Diagonal(numberOfColumns - 1, y, diagonalDirection, diagonalCells));
            }

            var cells = twoDimensionalCellArray.SelectMany(array => array)
                                               .ToList();

            var boardLines = columns.Concat<BoardLine>(rows)
                                    .Concat(diagonals)
                                    .ToList();
                                    

            return new Board(cells, boardLines, columns, rows, diagonals);
        }
    }
}