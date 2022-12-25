using flanne;
using HarmonyLib;
using static PowerupUnlimited.Plugin;

namespace PowerupUnlimited
{
    class PowerupGeneratorPatch
    {
        [HarmonyPatch(typeof(PowerupGenerator), "InitPowerupPool")]
        [HarmonyPrefix]
        static void InitPowerupPoolPrefix(ref int numTimesRepeatable)
        {
            if(!EndlessOnly.Value || SelectedMap.MapData.endless) {
                numTimesRepeatable = RepeatPowerups.Value;
            }
        }
    }
}