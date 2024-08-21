using HarmonyLib;
using GameNetcodeStuff;
using BepInEx.Logging;

namespace LethalArmor.Patches
{
    internal class Protect
    {
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.DamagePlayer))]
        [HarmonyPrefix]

        private static bool PlayerControllerB_DamagePlayer(PlayerControllerB __instance)
        {
            if (__instance.takingFallDamage && ArmorBase.hasVest)
            {
                ArmorBase.mls.LogInfo("Fall damage ignores armor...");
                return true;
            }
            if (ArmorBase.hits > 0 && ArmorBase.hasVest)
            {
                ArmorBase.mls.LogInfo("Hit armor!");
                ArmorBase.hits -= 1;
                SFX.PlaySFX.play_tankHit();
                if (ArmorBase.hits > 0)
                {
                    return false;
                }
            }
            ArmorBase.mls.LogInfo("No more armor...");
            SFX.PlaySFX.restore_takedamage();
            ArmorBase.hasVest = false;
            return true;
        }
    }

    internal class Prevent
    {
        [HarmonyPatch(typeof(PlayerControllerB), nameof(PlayerControllerB.KillPlayer))]
        [HarmonyPrefix]

        private static bool PlayerControllerB_KillPlayer(PlayerControllerB __instance)
        {
            if (ArmorBase.hits > 0 && !__instance.takingFallDamage && ArmorBase.hasVest)
            {
                ArmorBase.mls.LogInfo("Hit armor! - Prevented Death!!!");
                ArmorBase.hits -= 1;
                if (ArmorBase.hits > 0)
                {
                    return false;
                }
                else
                {
                    ArmorBase.hasVest = false;
                    SFX.PlaySFX.play_brokearmor();
                    return true;
                }
            }
            else
            {
                ArmorBase.hasVest = false;
                SFX.PlaySFX.play_brokearmor();
                return true;
            }
        }
    }
}
