﻿using System;

namespace sudoku.SudokuBoard
{
    public abstract class Region
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

        public Region MyRegion { get; set; }

        public virtual void Add(Region region)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Region region)
        {
            throw new NotImplementedException();
        }

        public virtual Region Get(int childNumber)
        {
            throw new NotImplementedException();
        }

        public virtual int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}