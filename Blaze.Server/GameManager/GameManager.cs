using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blaze.Server
{
    static class GameManager
    {
        public static Dictionary<ulong, Game> Games;

        private static int _gameID;

        static GameManager()
        {
            Games = new Dictionary<ulong, Game>();

            _gameID = 0;
        }

        public static void Add(Game game)
        {
            game.ID = (ulong)Interlocked.Increment(ref _gameID);
            Games.Add(game.ID, game);
        }
    }
}
