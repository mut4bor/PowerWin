using System.Text.Json;

public class ResolutionHotkey
{
    public required int Width { get; set; }
    public required int Height { get; set; }
    public required int RefreshRate { get; set; }
    public required string[] Hotkey { get; set; }
}

public class Config
{
    public required List<ResolutionHotkey> ResolutionHotkeys { get; set; }
}

public class ConfigManager
{
    private const string ConfigFilePath = "config.json";

    public static Config LoadConfig()
    {
        if (File.Exists(ConfigFilePath))
        {
            string json = File.ReadAllText(ConfigFilePath);
            return JsonSerializer.Deserialize<Config>(json);
        }
        return new Config { ResolutionHotkeys = new List<ResolutionHotkey>() };
    }

    public static void SaveConfig(Config config)
    {
        string json = JsonSerializer.Serialize(
            config,
            new JsonSerializerOptions { WriteIndented = true }
        );
        File.WriteAllText(ConfigFilePath, json);
    }
}
