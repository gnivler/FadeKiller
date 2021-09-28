using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using HarmonyLib;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace FadeKiller
{
    [HarmonyDebug]
    [HarmonyPatch]
    public class FadeManagerPatches
    {
        [HarmonyDebug]
        [HarmonyTargetMethods]
        private static IEnumerable<MethodInfo> TargetMethods()
        {
            yield return AccessTools.Method(typeof(FadeManager), "FadeFromBlack");
            yield return AccessTools.Method(typeof(FadeManager), "FadeOutIn");
            yield return AccessTools.Method(typeof(FadeManager), "FadeToBlack");
        }

        // ReSharper disable once RedundantAssignment
        public static void Prefix(FadeManager __instance, ref float duration)
        {
            duration = Mod.FadeTime.Value;
        }
    }
}
