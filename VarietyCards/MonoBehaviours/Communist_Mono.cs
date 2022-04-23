using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using HarmonyLib;
using UnityEngine;
using Photon.Pun;

namespace VarietyCards.MonoBehaviours
{
    internal class Communist_Mono : MonoBehaviour
    {
 

        private void Start()
		{

            this._player = base.GetComponentInParent<Player>();


        }
		private void Update()
        {

        }

        public void Damage(Vector2 damage, Vector2 position, GameObject damagingWeapon, Player damagingPlayer, Boolean lethal)
        {
            int players = PlayerManager.instance.players.Count;

            foreach (Player pl in PlayerManager.instance.players)
            {
                if (pl != this._player)
                {
                    Vector2 sharedDamage = (damage * 0.25f) / (players - 1);
                    Vector2 playerpos = (pl.data.transform.position);
                    if (damage == Vector2.zero)
                    {
                        return;
                    }
                    pl.data.view.RPC("RPCA_SendTakeDamage", RpcTarget.All, new object[]
                    {
                    sharedDamage,
                    playerpos,
                    lethal,
                    (damagingPlayer != null) ? damagingPlayer.playerID : -1
                    });
                }
            }
        }

        private Player _player;

    }
}
