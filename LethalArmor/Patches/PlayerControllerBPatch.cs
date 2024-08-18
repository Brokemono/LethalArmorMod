using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GameNetcodeStuff;
using HarmonyLib;

namespace LethalArmor.PlayerControllerBPatch
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    [HarmonyPatch("DamagePlayer")]
    internal class DamagePlayer_Patch
    {
        static bool Prefix(PlayerControllerB __instance, ref int damageNumber)
        {
            // Access the armor field in PlayerControllerB
            var armorField = __instance.GetType().GetField("armor", BindingFlags.Instance | BindingFlags.NonPublic);
            Armor armor = (Armor)armorField?.GetValue(__instance);

            // Check if armor is equipped and has durability
            if (armor != null && armor.IsEquipped && armor.Durability > 0)
            {
                armor.TakeDamage(); // Subtract 1 durability from armor

                // If the armor still has durability, skip the original method
                if (armor.Durability > 0)
                {
                    return false; // Skip original DamagePlayer method
                }
            }

            // Continue with the original DamagePlayer method if armor is broken or not equipped
            return true;
        }
    }
}
