using System.Text.Json;

namespace Bcml.Utils
{
    public class Settings
    {
        public Dictionary<string, JsonElement> Data { get; }

        /// <summary>
        /// <para>Params as of 3.9.24</para>
        /// <para></para>
        /// <c>load_reverse</c><br/>
        /// <c>no_guess</c><br/>
        /// <c>lang</c><br/>
        /// <c>no_cemu</c><br/>
        /// <c>wiiu</c><br/>
        /// <c>no_hardlinks</c><br/>
        /// <c>force_7z</c><br/>
        /// <c>suppress_update</c><br/>
        /// <c>loaded</c><br/>
        /// <c>nsfw</c><br/>
        /// <c>changelog</c><br/>
        /// <c>strip_gfx</c><br/>
        /// <c>auto_gb</c><br/>
        /// <c>show_gb</c><br/>
        /// <c>dark_theme</c><br/>
        /// </summary>
        public bool GetBool(string name) => Data != null && Data![name].GetBoolean();

        /// <summary>
        /// <para>Params as of 3.9.24</para>
        /// <para></para>
        /// <c>cemu_dir</c><br/>
        /// <c>game_dir</c><br/>
        /// <c>game_dir_nx</c><br/>
        /// <c>update_dir</c><br/>
        /// <c>dlc_dir</c><br/>
        /// <c>dlc_dir_nx</c><br/>
        /// <c>store_dir</c><br/>
        /// <c>export_dir</c><br/>
        /// <c>export_dir_nx</c><br/>
        /// <c>site_meta</c><br/>
        /// <c>last_version</c><br/>
        /// </summary>
        public string? GetString(string name) => Data != null ? Data![name].GetString() : null;

        public string? GetBase() => GetBool("wiiu") ? GetString("game_dir") : GetString("game_dir_nx");
        public string? GetUpdate() => GetBool("wiiu") ? GetString("update_dir") : GetString("game_dir_nx");
        public string? GetDlc() => GetBool("wiiu") ? GetString("dlc_dir") : GetString("dlc_dir_nx");

        public Settings()
        {
            var bytes = File.ReadAllBytes($"{Environment.GetEnvironmentVariable("LOCALAPPDATA")}\\bcml\\settings.json");
            Data = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(bytes) ?? new();
        }
    }
}
