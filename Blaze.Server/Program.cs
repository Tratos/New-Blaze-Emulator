using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blaze.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Initialize("Blaze.Server.log");
            Log.Info("Starting Blaze.Server...");

            Time.Initialize();

            try
            {
                Configuration.Load("Blaze.Server.yml");

                if (Configuration.Users == null)
                {
                    Log.Error("Users configuration was not found.");
                    return;
                }
            }
            catch (IOException)
            {
                Log.Error(string.Format("Could not open the configuration file {0}.", "Blaze.Server.yml"));
                return;
            }

            BlazeHubServer.Start();
            BlazeServer.Start();

            while (true)
            {
                try
                {
                    Log.WriteAway();
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                }

                Thread.Sleep(1000);
            }
        }
    }
}
