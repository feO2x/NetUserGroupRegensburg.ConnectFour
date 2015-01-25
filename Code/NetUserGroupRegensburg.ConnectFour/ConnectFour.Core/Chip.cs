using System;

namespace ConnectFour.Core
{
    public class Chip
    {
        public readonly string PlayerName;
        public readonly Color Color;

        public Chip(string playerName, Color color)
        {
            if (playerName == null) throw new ArgumentNullException("playerName");
            if (color == null) throw new ArgumentNullException("color");

            PlayerName = playerName;
            Color = color;
        }
    }
}
