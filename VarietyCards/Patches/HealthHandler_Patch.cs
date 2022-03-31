using System;
using HarmonyLib;
using VarietyCards.MonoBehaviours;
using UnityEngine;
using Photon.Pun;

namespace VarietyCards.Patches
{

    [HarmonyPatch(typeof(HealthHandler))]
    public class HealthHandler_Patch
    {

        [HarmonyPatch("CallTakeDamage")]
        [HarmonyPrefix]
        public static void CallTakeDamage(CharacterData ___data, Vector2 damage, Vector2 position, GameObject damagingWeapon, Player damagingPlayer, Boolean lethal)
        {
            if (___data.GetComponentInChildren<Communist_Mono>())
            {
                foreach (Communist_Mono com in ___data.GetComponentsInChildren<Communist_Mono>())
                {
                    com.Damage(damage, position, damagingWeapon, damagingPlayer, lethal);
                }
            }
        }

   


        [HarmonyPatch("Heal")]
        [HarmonyPrefix]
        public static void Heal(CharacterData ___data, float healAmount)
        {
            int players = PlayerManager.instance.players.Count;


            if (___data.GetComponentInChildren<Communist_Mono>())
            {   foreach (Communist_Mono com in ___data.GetComponentsInChildren<Communist_Mono>())
                {
                    com.Heal(healAmount);                    
                }
            }

            foreach (Player pl in PlayerManager.instance.players)
            {
                if (pl.data.GetComponentInChildren<Capitalist_Mono>() && pl != ___data.player)
                {
                    foreach (Capitalist_Mono cap in pl.data.GetComponentsInChildren<Capitalist_Mono>())
                    {
                        cap.Heal(healAmount);                      
                    }
                }
            }


          
        }
    }
}
 