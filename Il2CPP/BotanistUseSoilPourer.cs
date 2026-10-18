using System.Text.Json.Serialization;
using BotanistUseSoilPourer.Runtime;
using MelonLoader;

[assembly: MelonInfo(typeof(BotanistUseSoilPourer.BotanistUseSoilPourerMod), "Botanist Use Soil Pourer", "1.1.0", "Fortis")]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace BotanistUseSoilPourer;

public sealed class BotanistUseSoilPourerMod : MelonMod
{
    public override void OnInitializeMelon()
    {
        Configuration configuration = ConfigurationFile.Load(
            "BotanistUseSoilPourer",
            static () => new Configuration());

        RuntimeSettings.Configure(
            configuration.Enabled,
            sprinklerEnabled: false,
            configuration.Debug,
            configuration.AutoRefillSoilPourers,
            configuration.SoilPourerCapacity,
            configuration.AllowManualMultiBagFill);

        SoilPourerChargeStore.Initialize("BotanistUseSoilPourer");

        RuntimeSettings.Info(
            $"Botanist Use Soil Pourer 1.1.0 initialized for Schedule I 0.4.7f12. " +
            $"Enabled: {configuration.Enabled}; automatic refill: {configuration.AutoRefillSoilPourers}; " +
            $"capacity: {RuntimeSettings.SoilPourerCapacity}; " +
            $"manual multi-bag fill: {configuration.AllowManualMultiBagFill}; " +
            $"debug: {configuration.Debug}.");
    }
}

internal sealed class Configuration
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; } = true;

    [JsonPropertyName("autoRefillSoilPourers")]
    public bool AutoRefillSoilPourers { get; set; } = true;

    [JsonPropertyName("soilPourerCapacity")]
    public int SoilPourerCapacity { get; set; } = 2;

    [JsonPropertyName("allowManualMultiBagFill")]
    public bool AllowManualMultiBagFill { get; set; } = true;

    [JsonPropertyName("debug")]
    public bool Debug { get; set; }
}
