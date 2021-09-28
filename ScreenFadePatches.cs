using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using HarmonyLib;

namespace FadeKiller
{
    [HarmonyDebug]
    [HarmonyPatch]
    public static class ScreenFadePatches
    {
        [HarmonyDebug]
        [HarmonyTargetMethods]
        private static IEnumerable<MethodInfo> TargetMethods()
        {
            yield return AccessTools.Method(typeof(ScreenFade), "ClearFade");
            yield return AccessTools.Method(typeof(ScreenFade), "StartFade");
        }

        public static void Prefix(ref float seconds)
        {
            seconds = Mod.FadeTime.Value;
        }
    }
}
