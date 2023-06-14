using HarmonyLib;
using Steamworks.Data;
using static PowerupUnlimited.Plugin;

namespace PowerupUnlimited
{
    class LeaderboardPatch
    {
        [HarmonyPatch(typeof(Leaderboard), "SubmitScoreAsync")]
        [HarmonyPrefix]
        static bool SubmitScorePrefix()
        {
            return SubmitLeaderboard.Value;
        }
    }
}