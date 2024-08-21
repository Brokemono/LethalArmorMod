using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace LethalArmor.Patches
{
    internal class VestBehavior : PhysicsProp
    {
        //[HarmonyPrefix]
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (buttonDown && !ArmorBase.hasVest)
            {
                base.DestroyObjectInHand(playerHeldBy);
                ArmorBase.hasVest = true;
                ArmorBase.hits = 6;
                ArmorBase.mls.LogInfo("Equipped Armor");
            }
            else
            {
                if (ArmorBase.hasVest)
                {
                    ArmorBase.mls.LogInfo("Already equipped!");
                }
            }
        }
    }
}
