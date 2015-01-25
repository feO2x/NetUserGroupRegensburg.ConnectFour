using System;
using System.Collections.Generic;

namespace ConnectFour.Core
{
    public class Player
    {
        public readonly string Name;
        public readonly Color Color;
        public readonly IList<Chip> Chips;

        public Player(string name, Color color, IList<Chip> chips)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (color == null) throw new ArgumentNullException("color");
            if (chips == null) throw new ArgumentNullException("chips");

            Name = name;
            Color = color;
            Chips = chips;
        }

        public void PlaceChipInColumn(Column column)
        {
            if (column == null) throw new ArgumentNullException("column");
            if (Chips.Count == 0)
                throw new InvalidOperationException("Cannot place chip in column when player has no chips left.");

            var chip = Chips[0];
            Chips.RemoveAt(0);

            column.SetChip(chip);
        }
    }
}
