using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalArmor.PlayerControllerBPatch;

namespace LethalArmor
{
    [BepInPlugin("Brokemono.LethalArmor", "Lethal Armor", "1.0.0")]
    public class ArmorBase : BaseUnityPlugin
    {
        private static ArmorBase Instance;
        internal ManualLogSource mLs;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mLs = BepInEx.Logging.Logger.CreateLogSource("LethalArmor");

            mLs.LogInfo("Armor is born!");

            var harmony = new Harmony("Brokemono.LethalArmor");
            harmony.PatchAll(typeof(PlayerControllerBPatch.DamagePlayer_Patch));
        }
    }
}