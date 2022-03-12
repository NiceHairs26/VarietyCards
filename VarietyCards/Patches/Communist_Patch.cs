using System;
using HarmonyLib;
using VarietyCards.MonoBehaviours;
using UnityEngine;

namespace VarietyCards.Patches
{
    [HarmonyPatch(typeof(HealthHandler))]
    public class Communist_Patch
    {
        [HarmonyPatch("CallTakeDamage")]
        [HarmonyPrefix]
        public static bool CallTakeDamage(CharacterData _data, ref Vector2 damage, Vector2 position, GameObject damagingWeapon = null, Player damagingPlayer = null)
        {



            if (damagingPlayer != null && _data.GetComponent<Communist_Mono>())
            {
                return false;
            }


            return true; 
        
        
        
        }
    }
}
