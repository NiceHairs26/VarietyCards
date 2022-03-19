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


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

            cardInfo.allowMultiple = true;

            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {


            Capitalist_Mono cap = player.gameObject.AddComponent<Capitalist_Mono>();
            data.maxHealth *= 0.75f;

            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
         
        protected override string GetTitle()
        {
            return "Capitalist";
        }
        protected override string GetDescription()
        {
            return "You steal everyones heal.";
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
