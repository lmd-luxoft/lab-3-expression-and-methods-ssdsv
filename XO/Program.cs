using System;

namespace XO
{
    internal class Program
    {
        private readonly Board board;
        private readonly MoveDatasource moveDatasource;
        private readonly PlayerList players;

        public Program(string PlayerName1, string PlayerName2)
        {
            board = new Board();
            moveDatasource = new MoveDatasource();
            players = new PlayerList(PlayerName1, PlayerName2);
        }

        internal void Run()
        {
            board.ShowCells();

            for (int move = 1, maxCount = board.GetMaxMoveCount(); move <= maxCount; move++)
            {
                var currentPlayer = players.Next();

                MakeMove(currentPlayer);

                board.ShowCells();

                if (board.IsThereWinner())
                {
                    var anotherPlayer = players.Next();
                    DisplayWinMessage(currentPlayer, anotherPlayer);
                    return;
                }
            }

            DisplayNoWinnerMessage();
        }

        internal void MakeMove(Player player)
        {
            var cell = moveDatasource.GetNextMove(player.Name);
            board.PlaceMove(cell, player.Marker);
        }

        internal void DisplayWinMessage(Player winner, Player looser)
        {
            Console.WriteLine($"{winner.Name}, вы  выиграли, поздравляем. {looser.Name}, а вы проиграли...");
        }

        private static void DisplayNoWinnerMessage()
        {
            Console.WriteLine("Это была славная битва. Ничья.");
        }

        static void Main(string[] args)
        {
            string PlayerName1, PlayerName2;
            do
            {
                Console.Write("Введите имя первого игрока: ");
                PlayerName1 = Console.ReadLine();

                Console.Write("Введите имя второго игрока: ");
                PlayerName2 = Console.ReadLine();

                Console.WriteLine();
            } while (PlayerName1 == PlayerName2);

            var program = new Program(PlayerName1, PlayerName2);

            program.Run();

            Console.ReadLine();
        }

    }
}
