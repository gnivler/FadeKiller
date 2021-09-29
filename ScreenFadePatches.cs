using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

// ReSharper disable UnusedMember.Local

namespace FadeKiller
{
    [HarmonyPatch]
    public static class ScreenFadePatches
    {
        [HarmonyTargetMethods]
        private static IEnumerable<MethodInfo> TargetMethods()
        {
            yield return AccessTools.Method(typeof(ScreenFade), "ClearFade");
            yield return AccessTools.Method(typeof(ScreenFade), "StartFade");
        }

        // ReSharper disable once RedundantAssignment
        public static void Prefix(ref float seconds)
        {
            seconds = Mod.FadeTime.Value;
        }
    }
}
