﻿using System;
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
    class AutoBlock : CustomCard
    {


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            block.cdAdd += 0.25f;

            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            AutoBlock_Mono abm = player.gameObject.AddComponent<AutoBlock_Mono>();



            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
         
        protected override string GetTitle()
        {
            return "Lazy Block";
        }
        protected override string GetDescription()
        {
            return "You block as soon as your cooldown replenishes.\nNever block manually again!";
        }
        protected override GameObject GetCardArt()
        {
            return VarietyCards.AutoBlockArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block cooldown",
                    amount = "+0.25s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
        }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return VarietyCards.ModInitials;
        }
    }
}
