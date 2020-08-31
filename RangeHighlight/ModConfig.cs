// Copyright 2020 Jamie Taylor
using System;
using StardewModdingAPI;
using Microsoft.Xna.Framework;
namespace RangeHighlight {
    internal class ModConfig {
        public SButton ShowAllRangesKey { get; set; } = SButton.R;
        public SButton ShowSprinklerRangeKey { get; set; } = SButton.S;
        public SButton ShowScarecrowRangeKey { get; set; } = SButton.W;
        public SButton ShowBeehouseRangeKey { get; set; } = SButton.H;
        public SButton ShowJunimoRangeKey { get; set; } = SButton.J;

        public Color JunimoRangeTint { get; set; } = Color.White * 0.7f;
        public Color SprinklerRangeTint { get; set; } = new Color(0.6f, 0.6f, 0.9f, 0.7f);
        public Color ScarecrowRangeTint { get; set; } = new Color(0.6f, 1.0f, 0.6f, 0.7f);
        public Color BeehouseRangeTint { get; set; } = new Color(1.0f, 1.0f, 0.6f, 0.7f);
        public Color BombRangeTint { get; set; } = new Color(1.0f, 0.5f, 0.5f, 0.7f);
    }
}
