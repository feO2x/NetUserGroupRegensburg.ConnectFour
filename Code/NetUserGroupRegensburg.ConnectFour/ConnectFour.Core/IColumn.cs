﻿namespace ConnectFour.Core
{
    public interface IColumn
    {
        void SetChip(Chip chip);
        bool IsFull { get; }
    }
}