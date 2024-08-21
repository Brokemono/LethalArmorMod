using GameNetcodeStuff;
using HarmonyLib;

namespace LethalArmor.Patches
{
    internal class OnSpawn
    {
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.DamagePlayer))]
        [HarmonyPostfix]

        private static void PlayerControllerB_Reset(PlayerControllerB __instance)
        {
            if (__instance.isPlayerDead)
            {
                ArmorBase.mls.LogInfo("Player died?");
            }
        }
    }
}
