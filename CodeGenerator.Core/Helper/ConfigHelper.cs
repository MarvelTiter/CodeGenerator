using CodeGenerator.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Core.Helper
{
    public class ConfigHelper
    {
        public const string ConfigFileName = "config.json";
        public static Config ReadConfig()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
            if (!File.Exists(file)) return null;
            file = File.ReadAllText(file);
            try
            {
                var config = System.Text.Json.JsonSerializer.Deserialize<Config>(file);
                return config;
            }
            catch
            {
                return null;
            }
        }

        public static async Task SaveConfig(Config config)
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), ConfigFileName);
            if (File.Exists(file)) 
                File.Delete(file);
            var contentString = System.Text.Json.JsonSerializer.Serialize(config);
            using var fs = File.Open(file, FileMode.CreateNew, FileAccess.Write, FileShare.ReadWrite);
            var data = Encoding.Default.GetBytes(contentString);
            await fs.WriteAsync(data, 0, data.Length);
            await fs.FlushAsync();
        }
    }
}
