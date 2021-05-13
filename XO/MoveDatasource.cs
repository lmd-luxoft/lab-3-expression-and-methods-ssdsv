using System;
using System.Collections.Generic;

namespace XO
{
    internal class MoveDatasource
    {
        private ISet<int> _previousMoves = new HashSet<int>();

        public MoveDatasource()
        {
        }

        public int GetNextMove(string playerName)
        {
            string raw_cell;
            int cell;

            do
            {
                Console.Write($"{playerName},введите номер ячейки,сделайте свой ход:");

                raw_cell = Console.ReadLine();
            }
            while (!Int32.TryParse(raw_cell, out cell));

            while (cell > 9 || cell < 1 || _previousMoves.Contains(cell))
            {
                do
                {
                    Console.Write("Введите номер правильного ( 1-9 ) или пустой ( --- ) клетки , чтобы сделать ход:");
                    raw_cell = Console.ReadLine();
                }
                while (!Int32.TryParse(raw_cell, out cell));

                Console.WriteLine();
            }

            return cell;
        }
    }
}
