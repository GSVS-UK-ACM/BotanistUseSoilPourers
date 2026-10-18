# BotanistUseSoilPourers

Botanists can use linked soil pourers while working with pots. This repository was created by Fortis.

Version 1.1.0 updates the IL2CPP build for Schedule I 0.4.7f12.

## What changed

- Uses the current grow-container behaviours instead of the removed `PotActionBehaviour` type.
- Detects linked soil pourers and lets botanists use them during the planting workflow.
- Supports a configurable capacity from 1 to 8 soil bags. The default is 2.
- Consumes one stored charge for each pot filled.
- Allows manual and botanist soil-pourer top-ups.
- Lets idle botanists refill pourers before the next planting cycle.
- Keeps the seed handoff ready so planting can continue after soil is dispensed.
- Uses host-authoritative charge state in multiplayer.
- Falls back to the normal soil-bag workflow when a pourer cannot be used.
- Reduces unnecessary device scans and stops off-hours polling from 04:00 to 07:00.

## Configuration

The configuration file is created at:

`UserData/BotanistUseSoilPourer/configuration.json`

Default configuration:

```json
{
  "enabled": true,
  "autoRefillSoilPourers": true,
  "soilPourerCapacity": 2,
  "allowManualMultiBagFill": true,
  "debug": false
}
```

- `enabled` turns the mod on or off.
- `autoRefillSoilPourers` lets botanists top up linked pourers when they would otherwise be idle.
- `soilPourerCapacity` sets how many soil bags each pourer can hold, from 1 to 8.
- `allowManualMultiBagFill` enables the player interaction for inserting extra soil bags.
- `debug` enables extra diagnostic logging.

## Installation

1. Install MelonLoader for the IL2CPP version of Schedule I.
2. Put `BotanistUseSoilPourer.dll` in the game's `Mods` folder.
3. In multiplayer, every participant should use the same DLL and configuration.

The Mono project is retained for reference. It is not part of this compatibility update.

## Building

Build with .NET 6 and point `MelonLoaderRoot` at the game's MelonLoader directory:

```powershell
dotnet build Il2CPP/BotanistUseSoilPourer.csproj --configuration Release --property:MelonLoaderRoot="C:\Program Files (x86)\Steam\steamapps\common\Schedule I\MelonLoader"
```

Game and MelonLoader assemblies are referenced from the local installation. They are not committed to this repository.

## Credits

- Original mod by Fortis.
- Schedule I 0.4.7f12 compatibility update contributed by GSVS UK ACM / xboxnuker-rgb.
