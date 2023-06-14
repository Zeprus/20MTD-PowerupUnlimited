using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System;

namespace PowerupUnlimited
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<int> RepeatPowerups;
        public static ConfigEntry<bool> EndlessOnly;
        public static ConfigEntry<bool> SubmitLeaderboard;
        internal static ManualLogSource Log;
        private void Awake()
        {
            RepeatPowerups = Config.Bind<int>("General", "RepeatPowerups", -1, "Amount of times powerups can repeat before the pool is depleted." + System.Environment.NewLine + "-1 for unlimited." + System.Environment.NewLine + "Game default: 3");
            EndlessOnly = Config.Bind<bool>("General", "EndlessOnly", true, "Only apply Powerup amount changes to endless.");
            SubmitLeaderboard = Config.Bind<bool>("General", "SubmitLeaderboard", false, "Submit endless scores to the leaderboard with the mod enabled. Cheater.");

            Log = Logger;

            try
            {
                Harmony.CreateAndPatchAll(typeof(PowerupGeneratorPatch));
                Harmony.CreateAndPatchAll(typeof(LeaderboardPatch));
            }
            catch (Exception e)
            {
                Log.LogError(e.Message);
            }
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
