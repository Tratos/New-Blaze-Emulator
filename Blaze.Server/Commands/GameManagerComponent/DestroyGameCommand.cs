using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class DestroyGameCommand
    {
        public static void HandleRequest(Request request)
        {
            var gameID = (TdfInteger)request.Data["GID"];

            /* if (!GameManager.Games.ContainsKey(gameID.Value))
            {
                request.Reply(0x12D0004, null);
                return;
            } */

            //request.Reply();
        }
    }
}
