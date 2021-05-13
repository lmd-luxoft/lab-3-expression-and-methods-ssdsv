using System;
using System.Linq;

namespace XO
{
    internal class Board
    {
        private const char PLACEHOLDER = '-';
        private const int ROW_COUNT = 3;
        private const int COLUMN_COUNT = 3;
        public const int PLACE_COUNT = ROW_COUNT * COLUMN_COUNT;
        private const int MOVE_COUNT_BEFORE_FIRST_CHECK = 5;

        private char[] cells = Enumerable.Repeat(PLACEHOLDER, PLACE_COUNT).ToArray();
        private int MoveCount = 0;

        public Board()
        {
        }

        internal int GetMaxMoveCount() => PLACE_COUNT;

        internal void ShowCells()
        {
            Console.Clear();

            Console.WriteLine("Числа клеток:");
            Console.WriteLine("-1-|-2-|-3-");
            Console.WriteLine("-4-|-5-|-6-");
            Console.WriteLine("-7-|-8-|-9-");

            Console.WriteLine("Текущая ситуация (---пустой):");
            Console.WriteLine($"-{cells[0]}-|-{cells[1]}-|-{cells[2]}-");
            Console.WriteLine($"-{cells[3]}-|-{cells[4]}-|-{cells[5]}-");
            Console.WriteLine($"-{cells[6]}-|-{cells[7]}-|-{cells[8]}-");
        }

        internal void PlaceMove(int cell, char marker)
        {
            cells[cell - 1] = marker;
            MoveCount++;
        }

        internal bool IsThereWinner()
        {
            if (MoveCount < MOVE_COUNT_BEFORE_FIRST_CHECK)
                return false;

            if (IsDiagonalWin())
                return true;

            for (int i = 0; i < ROW_COUNT; i++)
            {
                if (IsRowWin(i))
                    return true;

                if (IsColumnWin(i))
                    return true;
            }

            return false;
        }

        private bool IsColumnWin(int column)
        {
            if (cells[column] == PLACEHOLDER)
                return false;

            return cells[column] == cells[column + 3]
                   && cells[column + 3] == cells[column + 6];
        }

        private bool IsRowWin(int row)
        {
            var firstIndex = row * 3;
            
            if (cells[firstIndex] == PLACEHOLDER)
                return false;

            return cells[firstIndex] == cells[firstIndex + 1]
                   && cells[firstIndex + 1] == cells[firstIndex + 2];
        }

        private bool IsDiagonalWin()
        {
            if (cells[4] == PLACEHOLDER)
                return false;
            
            return (cells[2] == cells[4] && cells[4] == cells[6]) || (cells[0] == cells[4] && cells[4] == cells[8]);
        }


    }
}
