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
    class Communist : CustomCard
    {


        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

            cardInfo.allowMultiple = true;

            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {


            Communist_Mono com = player.gameObject.AddComponent<Communist_Mono>();


            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Debug.Log($"[{VarietyCards.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
         
        protected override string GetTitle()
        {
            return "Communist";
        }
        protected override string GetDescription()
        {
            return "Everyone is partaking on the damage and heal you receive.";
        }
        protected override GameObject GetCardArt()
        {
            return VarietyCards.CommunistArt;
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
                    stat = "Communism",
                    amount = "+25%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                } 
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.FirepowerYellow;
        }
        public override string GetModName()
        {
            return VarietyCards.ModInitials;
        }
    }
}
