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
    class HungryBlock : CustomCard
    {
        GameObject gameobj;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            

        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            this.gameobj = new GameObject(this.GetTitle() + "[MonoHolder]");
            this.gameobj.transform.parent = data.transform;
            characterStats.objectsAddedToPlayer.Add(this.gameobj);
            this.gameobj.AddComponent<HungryBlock_Mono>();

            foreach (Player pl in PlayerManager.instance.players)
            {
                pl.gameObject.GetOrAddComponent<SoundManager_Mono>();
            }

            statModifiers.lifeSteal += 0.5f;
            block.cdMultiplier *= 0.5f;

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            UnityEngine.Object.Destroy(this.gameobj);
        }

        protected override string GetTitle()
        {
            return "Hungry Block";
        }
        protected override string GetDescription()
        {          
            return "Blocking costs 15HP, removes block cooldown. Be wary of deminishing returns, block cooldown still applies here.";
        }
        protected override GameObject GetCardArt()
        {
            return VarietyCards.HungryBlockArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Life steal",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return VarietyCards.ModInitials;
        }
    }
}
