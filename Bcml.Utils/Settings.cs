using System.Text.Json;

namespace Bcml.Utils
{
    /// <summary>
    /// <para>Params as of 3.9.24</para>
    /// <para></para>
    /// <c>*str</c>: cemu_dir<br/>
    /// <c>*str</c>: game_dir<br/>
    /// <c>*str</c>: game_dir_nx<br/>
    /// <c>*str</c>: update_dir<br/>
    /// <c>*str</c>: dlc_dir<br/>
    /// <c>*str</c>: dlc_dir_nx<br/>
    /// <c>*str</c>: store_dir<br/>
    /// <c>*str</c>: export_dir<br/>
    /// <c>*str</c>: export_dir_nx<br/>
    /// <c>bool</c>: load_reverse<br/>
    /// <c>*str</c>: site_met""<br/>
    /// <c>bool</c>: no_guess<br/>
    /// <c>bool</c>: lang<br/>
    /// <c>bool</c>: no_cemu<br/>
    /// <c>bool</c>: wiiu<br/>
    /// <c>bool</c>: no_hardlinks<br/>
    /// <c>bool</c>: force_7z<br/>
    /// <c>bool</c>: suppress_update<br/>
    /// <c>bool</c>: loaded<br/>
    /// <c>bool</c>: nsfw<br/>
    /// <c>bool</c>: changelog<br/>
    /// <c>bool</c>: strip_gfx<br/>
    /// <c>bool</c>: auto_gb<br/>
    /// <c>bool</c>: show_gb<br/>
    /// <c>bool</c>: dark_theme<br/>
    /// <c>*str</c>: last_version<br/>
    /// </summary>
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
