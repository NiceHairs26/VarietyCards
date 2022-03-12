using System;
using HarmonyLib;
using VarietyCards.MonoBehaviours;
using UnityEngine;

namespace VarietyCards.Patches
{
    [HarmonyPatch(typeof(HealthHandler))]
    public class HealthHandler_Patch
    {
        [HarmonyPatch("CallTakeDamage")]
        [HarmonyPrefix]
        public static bool CallTakeDamage(CharacterData ___data, Vector2 damage, Vector2 position, GameObject damagingWeapon, Player damagingPlayer, Boolean lethal)
        {
            if (___data.GetComponent<Communist_Mono>())
            {
                int players = PlayerManager.instance.players.Count;

                for (int i = 0; i < players; i++)
                {
                    if(PlayerManager.instance.players[i] != ___data.player)
                    {
                        Vector2 sharedDamage = ((damage * 0.1f) * (___data.GetComponents<Communist_Mono>().Length)) / (players-1);                       
                        PlayerManager.instance.players[i].data.healthHandler.TakeDamage(sharedDamage,position*0);
                    }
                }
            }
            return true; 
        }

        [HarmonyPatch("Heal")]
        [HarmonyPrefix]
        public static void Heal(CharacterData ___data, float healAmount)
        {

            if (___data.GetComponent<Communist_Mono>())
            {
                int players = PlayerManager.instance.players.Count;

                for (int i = 0; i < players; i++)
                {
                    if (PlayerManager.instance.players[i] != ___data.player)
                    {
                        float sharedHeal = ((healAmount * 0.1f) * (___data.GetComponents<Communist_Mono>().Length)) / (players - 1);
                        PlayerManager.instance.players[i].data.healthHandler.Heal(sharedHeal);
                    }
                }
             

            }
        
        }

    }
}
 