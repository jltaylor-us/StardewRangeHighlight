# Stardew Valley Range Highlight

A Stardew Valley SMAPI mod for adding range highlighting.

## For mod users

This mod adds highlighting for the range of the following items and buildings:

* Sprinklers (including the Prismatic Sprinkler from the Prismatic Tools mod)
* Scarecrows (including the Deluxe Scarecrow)
* Bee Houses
* Junimo Huts

Ranges are shown automatically when the corresponding item is equipped,
or when the cursor is over a building of the appropriate type.  Hold down one
of the configured hotkeys (see [Configuration](#configuration) below) to show ranges regardless of cursor
position or what item is equipped.  Each range type has a different
highlight color, which is also configurable (see [Configuration](#configuration) below).

See the [Screenshots](Screenshots/) directory for some examples.

### Compatibility

Works with Stardew Valley 1.4, single player and multiplayer.
No known incompatibilities with other mods, although if another mod also
shows range highlights (e.g., UI Info Suite) then each mod will show
its own highlight.  The result is not horrible, but you probably
want to disable the other mod's range highlighting if possible (for example, by
using UI Info Suite's in-game menu to disable its range highlighting).

### Installation

Follow the usual installation proceedure for SMAPI mods:
1. Install [SMAPI](https://smapi.io)
2. Download the latest realease of this mod and unzip it into the `Mods` directory
3. Run the game using SMAPI

### Configuration

When SMAPI runs the mod for the first time it will create a `config.json`
in the mod directory.  You can edit this file to configure the hotkeys and
highlight colors.  The default configuration is summarized in the table below.

| | hotkey | highlight tint
| --- | --- | ---
| All **R**ange Highlights | `R` | as listed below
| **S**prinklers | `S` | blue
| Scarecro**w**s | `W` | green
| Bee **H**ouses | `H` | yellow
| **J**unimo Huts | `J` | white

## For mod developers

This mod provides an API for adding highlighting to items and buildings.
It then uses this API to add highlights as described above.  The API includes
functions to:
* Describe common highlight shapes
* Get the tint colors configured for this mod
* Add highlighters based on `Building` object or item name

For the full API, see [`IRangeHighlightAPI.cs`](https://github.com/jltaylor-us/StardewRangeHighlight/blob/default/RangeHighlight/IRangeHighlightAPI.cs).

For general information on how to use another mod's API in your mod,
see the [Mod Integration](https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Integrations)
page on the Stardew Valley Wiki.
