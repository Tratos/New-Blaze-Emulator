using System.Collections.Generic;
using System.IO;

using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Blaze.Server
{
    public class Configuration
    {
        public struct Config
        {
            public List<User> Users { get; set; }
        }

        public static void Load(string filename)
        {
            var buffer = File.ReadAllText("data/" + filename);

            Log.Info($"Load Configurations : {buffer}");

            var deserializer = new Deserializer(ignoreUnmatched: true);
            var config = deserializer.Deserialize<Config>(new StringReader(buffer));

            Users = config.Users;
        }

        public static List<User> Users { get; set; }
    }

    public class User
    {
        public ulong ID { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }
    }
}
