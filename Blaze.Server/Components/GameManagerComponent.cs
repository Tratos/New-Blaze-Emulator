using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class GameManagerComponent
    {
        public static void HandleRequest(Request request)
        {
            switch (request.CommandID)
            {
                case 1:
                    CreateGameCommand.HandleRequest(request);
                    break;

                case 2:
                    Log.Warn("DESTROY GAME");
                    break;

                case 3:
                    AdvanceGameStateCommand.HandleRequest(request);
                    break;

                case 4:
                    SetGameSettingsCommand.HandleRequest(request);
                    break;

                case 5:
                    Log.Info("SET PLAYER CAPACITY");
                    //SetPlayerCapacityCommand.HandleRequest(request);
                    break;

                case 7:
                    Log.Info("SET GAME ATTRIBUTES");
                    //SetGameAttributesCommand.HandleRequest(request);
                    break;

                case 9:
                    JoinGameCommand.HandleRequest(request);
                    break;

                case 0xB:
                    Log.Warn("*GameManager->HandleRemovePlayerCommand*");
                    //HandleRemovePlayerCommand(clientId, request, stream);
                    break;

                case 0xF:
                    FinalizeGameCreationCommand.HandleRequest(request);
                    break;

                case 0x1D:
                    UpdateMeshConnectionCommand.HandleRequest(request);
                    break;

                default:
                    Log.Warn(string.Format("Unhandled request: {0} {1}", request.ComponentID, request.CommandID));
                    break;
            }
        }
    }
}
