// Copyright 2020 Jamie Taylor
using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buildings;

namespace RangeHighlight {
    public class ModEntry : Mod {
        internal ModConfig config;
        internal RangeHighlighter highlighter;
        private IRangeHighlightAPI api;
        private DefaultShapes defaultShapes;

        public override void Entry(IModHelper helper) {
            config = helper.ReadConfig<ModConfig>();
            highlighter = new RangeHighlighter(helper, config);
            api = new RangeHighlightAPI(this);
            defaultShapes = new DefaultShapes(api);
            installDefaultHighlights();
        }

        public override object GetApi() {
            return api;
        }

        private class DefaultShapes {
            public readonly bool[,] sprinkler = {
                { false, true, false},
                { true, false, true },
                { false, true, false}};
            public readonly bool[,] qualitySprinkler;
            public readonly bool[,] iridiumSprinkler;
            public readonly bool[,] prismaticSprinkler;
            public readonly bool[,] beehouse;
            public readonly bool[,] scarecrow;
            public readonly bool[,] deluxeScarecrow;
            public readonly bool[,] junimoHut;

            public DefaultShapes(IRangeHighlightAPI api) {
                qualitySprinkler = api.GetSquareCircle(1);
                iridiumSprinkler = api.GetSquareCircle(2);
                prismaticSprinkler = api.GetSquareCircle(3);
                beehouse = api.GetManhattanCircle(5);
                scarecrow = api.GetCartesianCircle(8);
                deluxeScarecrow = api.GetCartesianCircle(16);
                junimoHut = api.GetSquareCircle(8);
                junimoHut[7, 7] = junimoHut[8, 7] = junimoHut[9, 7] = junimoHut[7, 8] = junimoHut[9, 8] = false;
            }

            public bool[,] GetSprinkler(string name) {
                if (name.Contains("iridium")) return iridiumSprinkler;
                if (name.Contains("quality")) return qualitySprinkler;
                if (name.Contains("prismatic")) return prismaticSprinkler;
                return sprinkler;
            }
        }

        private void installDefaultHighlights() {
            api.AddBuildingRangeHighlighter("jltaylor-us.RangeHighlight/junimoHut", config.ShowJunimoRangeKey,
                building => {
                    if (building is JunimoHut) {
                        return new Tuple<Color, bool[,], int, int>(config.JunimoRangeTint, defaultShapes.junimoHut, 1, 1);
                    } else {
                        return null;
                    }
                });
            api.AddItemRangeHighlighter("jltaylor-us.RangeHighlight/scarecrow", config.ShowScarecrowRangeKey,
                itemName => {
                    if (itemName.Contains("arecrow")) {
                        return new Tuple<Color, bool[,]>(config.ScarecrowRangeTint,
                            itemName.Contains("deluxe") ? defaultShapes.deluxeScarecrow : defaultShapes.scarecrow);
                    } else {
                        return null;
                    }
                });
            api.AddItemRangeHighlighter("jltaylor-us.RangeHighlight/sprinkler", config.ShowSprinklerRangeKey,
                itemName => {
                    if (itemName.Contains("sprinkler")) {
                        return new Tuple<Color, bool[,]>(config.SprinklerRangeTint, defaultShapes.GetSprinkler(itemName));
                    } else {
                        return null;
                    }
                });
            api.AddItemRangeHighlighter("jltaylor-us.RangeHighlight/beehouse", config.ShowBeehouseRangeKey,
                itemName => {
                    if (itemName.Contains("bee house")) {
                        return new Tuple<Color, bool[,]>(config.BeehouseRangeTint, defaultShapes.beehouse);
                    } else {
                        return null;
                    }
                });

        }
    }
}
