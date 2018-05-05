using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class UserSettingsSaveCommand
    {
        public static void HandleRequest(Request request)
        {
            Log.Info(string.Format("Client {0} saving user settings for user {1}", request.Client.ID, request.Client.User.ID));

            var data = (TdfString)request.Data["DATA"];

            Directory.CreateDirectory(string.Format(".\\data\\{0}", request.Client.User.ID));

            if (File.Exists(string.Format(".\\data\\{0}\\user_settings", request.Client.User.ID)))
            {
                File.Delete(string.Format(".\\data\\{0}\\user_settings", request.Client.User.ID));
            }

            File.WriteAllBytes(string.Format(".\\data\\{0}\\user_settings", request.Client.User.ID), Encoding.ASCII.GetBytes(data.Value));

            request.Reply();
        }
    }
}
