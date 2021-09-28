using System.IO;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace FadeKiller
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public class Mod : BaseUnityPlugin
    {
        private const string PluginGUID = "ca.gnivler.sheltered2.FadeKiller";
        private const string PluginName = "FadeKiller";
        private const string PluginVersion = "1.0.0";

        internal static ConfigEntry<float> FadeTime;

        private void Awake()
        {
            Harmony harmony = new("ca.gnivler.sheltered2.FadeKiller");
            Log("FadeKiller Startup");
            harmony.PatchAll(typeof(Patches));
            harmony.PatchAll(typeof(FadeManagerPatches));
            harmony.PatchAll(typeof(ScreenFadePatches));
            FadeTime = Config.Bind(new ConfigDefinition("Settings", "Fade time"), 0f, new ConfigDescription("Set how long the fades last.", new AcceptableValueRange<float>(0f, 5f)));
        }

        internal static void Log(object input)
        {
            File.AppendAllText("log.txt", $"{input ?? "null"}\n");
        }
    }
}
