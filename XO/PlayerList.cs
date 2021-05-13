using System.Collections.Generic;

namespace XO
{
    internal class PlayerList
    {
        private Player playerCross;
        private Player playerZero;
        private IEnumerator<Player> _enumerator;
        
        public PlayerList(string player1, string player2)
        {
            playerCross = new Player(player1, 'X');
            playerZero = new Player(player2, 'O');
            _enumerator = InfiniteEnumerable().GetEnumerator();
        }

        private IEnumerable<Player> InfiniteEnumerable()
        {
            while (true)
            {
                yield return playerCross;
                yield return playerZero;
            }
        }

        public Player Next()
        {
            _enumerator.MoveNext();
            return _enumerator.Current;
        }
    }
}