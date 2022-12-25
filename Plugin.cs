using BepInEx;
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
        private void Awake()
        {
            RepeatPowerups = Config.Bind<int>("General", "RepeatPowerups", -1, "Amount of times powerups can repeat before the pool is depleted." + System.Environment.NewLine + "-1 for unlimited." + System.Environment.NewLine + "Game default: 3");
            EndlessOnly = Config.Bind<bool>("General", "EndlessOnly", true, "Only apply Powerup amount changes to endless.");

            // Plugin startup logic
            try
            {
                Harmony.CreateAndPatchAll(typeof(PowerupGeneratorPatch));
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
            }
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
