using System.Text.Json;

namespace Bcml.Utils
{
    public class Settings
    {
        public Dictionary<string, object?>? Data { get; }

        public bool? GetBool(string name) => Data != null ? (Data![name] as bool?) : false;
        public string? GetString(string name) => Data != null ? (Data![name] as string) : null;

        public Settings()
        {
            var bytes = File.ReadAllBytes($"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\bcml");
            Data = JsonSerializer.Deserialize<Dictionary<string, object?>>(bytes);
        }
    }
}
