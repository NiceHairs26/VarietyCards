using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using VarietyCards.MonoBehaviours;

namespace VarietyCards.Cards
{
    class Capitalist : CustomCard
    {
        GameObject gameobj;

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

            cardInfo.allowMultiple = true;

      
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {


            this.gameobj = new GameObject(this.GetTitle() + "[MonoHolder]");
            this.gameobj.transform.parent = data.transform;
            characterStats.objectsAddedToPlayer.Add(this.gameobj);
            this.gameobj.AddComponent<Capitalist_Mono>();

            data.maxHealth *= 0.75f;

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Object.Destroy(this.gameobj);
        }
         
        protected override string GetTitle()
        {
            return "Capitalist";
        }
        protected override string GetDescription()
        {
            return "You partake on everyone's heal.";
        }
        protected override GameObject GetCardArt()
        {
            return VarietyCards.CapitalistArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Capitalism",
                    amount = "+10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Health",
                    amount = "-25%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return VarietyCards.ModInitials;
        }
    }
}
