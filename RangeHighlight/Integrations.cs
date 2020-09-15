// Copyright 2020 Jamie Taylor
using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;

namespace RangeHighlight {
    internal class Integrations {
        private IModHelper helper;
        private IRangeHighlightAPI highlightApi;
        private ModConfig config;
        private ModEntry.DefaultShapes defaultShapes;
        public Integrations(IModHelper helper, IRangeHighlightAPI api, ModConfig config, ModEntry.DefaultShapes defaultShapes) {
            this.helper = helper;
            this.highlightApi = api;
            this.config = config;
            this.defaultShapes = defaultShapes;
            IntegratePrismaticTools();
        }

        private void IntegratePrismaticTools() {
            IPrismaticToolsAPI api = helper.ModRegistry.GetApi<IPrismaticToolsAPI>("stokastic.PrismaticTools");
            if (api == null) return;
            defaultShapes.prismaticSprinkler = highlightApi.GetSquareCircle((uint)api.SprinklerRange);
        }
    }

    public interface IPrismaticToolsAPI {
        int SprinklerRange { get; }
        int SprinklerIndex { get; }
    }
}
