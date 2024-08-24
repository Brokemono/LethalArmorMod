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
            if (__instance.AllowPlayerDeath())
            {
                ArmorBase.mls.LogInfo("Player died?");
                ArmorBase.hasVest = false;
            }
			else
			{
                ArmorBase.mls.LogInfo("Not dead yet!");
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