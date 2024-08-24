using GameNetcodeStuff;
using HarmonyLib;

namespace LethalArmor.Patches
{
    internal class OnSpawn
    {
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.DamagePlayer))]
        [HarmonyPrefix]

        private static void PlayerControllerB_Reset(PlayerControllerB __instance)
        {
            if (__instance.isPlayerDead)
            {
                ArmorBase.mls.LogInfo("Player died?");
            }
        }
    }
}

/*
public enum CauseOfDeath
{
	Unknown,
	Bludgeoning,
	Gravity,
	Blast,
	Strangulation,
	Suffocation,
	Mauling,
	Gunshots,
	Crushing,
	Drowning,
	Abandoned,
	Electrocution,
	Kicking,
	Burning,
	Stabbing,
	Fan,
	Inertia,
	Snipped
}
*/