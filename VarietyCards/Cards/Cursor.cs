using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using VarietyCards.MonoBehaviours.Cursor;

namespace VarietyCards.Cards
{
    class Cursor : CustomCard
    {
        GameObject gameobj;
        CursorSet_Mono cusm;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = true;
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {

            this.gameobj = new GameObject(this.GetTitle() + "[MonoHolder]");
            this.gameobj.transform.parent = data.transform;
            characterStats.objectsAddedToPlayer.Add(this.gameobj);
            this.cusm = this.gameobj.GetOrAddComponent<CursorSet_Mono>();

            this.cusm.monoHold =this.gameobj;
            this.cusm.Add(1);


        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Object.Destroy(this.gameobj);
        }

        protected override string GetTitle()
        {
            return "Cursor";
        }
        protected override string GetDescription()
        {          
            return "Adds an cursor to the player that'll heal you by 5 hp every 10 seconds.";
        }
        protected override GameObject GetCardArt()
        {
            return null;
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
                    stat = "Cursor",
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return VarietyCards.ModInitials;
        }
    }
}
