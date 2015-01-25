using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConnectFour.Core.Tests
{
    [TestClass]
    public class ColumnTests
    {
        [TestMethod]
        public void ChipCanBeAddedToColumnWhenItIsNotFull()
        {
            // Arrange
            var columnCells = new List<Cell>
                              {
                                  new Cell(0, 0),
                                  new Cell(0, 1),
                                  new Cell(0, 2),
                                  new Cell(0, 3),
                                  new Cell(0, 4),
                                  new Cell(0, 5)
                              };
            var testTarget = new Column(columnCells);
            var chip = new Chip("Foo", new Color(128, 0, 0));

            // Act
            testTarget.SetChip(chip);

            // Assert
            Assert.AreEqual(chip, columnCells[0].Chip);
        }
    }
}
