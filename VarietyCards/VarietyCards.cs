using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using VarietyCards.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace VarietyCards
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]

    
    public class VarietyCards : BaseUnityPlugin
    {
        private const string ModId = "com.NiceHairs.VarietyCards";
        private const string ModName = "VarietyCards";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "VC";
        public static VarietyCards instance { get; private set; }


        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();

        }
        void Start()
        {
            instance = this;

            CustomCard.BuildCard<AutoBlock>();
            //CustomCard.BuildCard<TacticalBlock>();
            CustomCard.BuildCard<Communist>();
            CustomCard.BuildCard<Capitalist>();
            CustomCard.BuildCard<Pretender>();
        }

        private static readonly AssetBundle Bundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("varietycardsassetbundel", typeof(VarietyCards).Assembly);

        public static GameObject AutoBlockArt = Bundle.LoadAsset<GameObject>("C_AutoBlock");
        public static GameObject TacticalBlockArt = Bundle.LoadAsset<GameObject>("C_TacticalBlock");
        public static GameObject CommunistArt = Bundle.LoadAsset<GameObject>("C_Communist");
        public static GameObject CapitalistArt = Bundle.LoadAsset<GameObject>("C_Capitalist");
        public static GameObject PretenderArt = Bundle.LoadAsset<GameObject>("C_Pretender");

    }



}
