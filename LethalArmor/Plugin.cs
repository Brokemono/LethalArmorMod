using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalArmor.Patches;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace LethalArmor
{
    [BepInPlugin("Brokemono.LethalArmor", "Lethal Armor", "1.0.0")]
    public class ArmorBase : BaseUnityPlugin
    {
        private static ArmorBase Instance;
        public static ManualLogSource mls;

        public static int hits = 0;
        public static bool hasVest = false;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource("LethalArmor");

            var harmony = new Harmony("Brokemono.LethalArmor");
            Harmony.CreateAndPatchAll(typeof(Protect));
            Harmony.CreateAndPatchAll(typeof(Prevent));
            Harmony.CreateAndPatchAll(typeof(OnSpawn));
            Harmony.CreateAndPatchAll(typeof(VestBehavior));

            string assetDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "itemmod");
            AssetBundle bundle = AssetBundle.LoadFromFile(assetDir);

            Item ArmorVestItem = bundle.LoadAsset<Item>("Assets/Items/ArmorVestItem.asset");

            VestBehavior script = ArmorVestItem.spawnPrefab.AddComponent<VestBehavior>();
            script.grabbable = true;
            script.grabbableToEnemies = true;
            script.itemProperties = ArmorVestItem;

            NetworkPrefabs.RegisterNetworkPrefab(ArmorVestItem.spawnPrefab);
            Utilities.FixMixerGroups(ArmorVestItem.spawnPrefab);
            Items.RegisterScrap(ArmorVestItem, 5, Levels.LevelTypes.All);
            TerminalNode node = ScriptableObject.CreateInstance<TerminalNode>();
            node.clearPreviousText = true;
            node.displayText = "You can tank some hits with this armor...\n\n";
            Items.RegisterShopItem(ArmorVestItem, null, null, node, 0);

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), "Brokemono.LethalArmor");

            mls.LogInfo("Loaded LethalArmor");
        }
    }
}