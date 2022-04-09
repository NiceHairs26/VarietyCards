using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnityEngine;
using Sonigon;
using Sonigon.Internal;

namespace VarietyCards.MonoBehaviours
{
    internal class HungryBlock_Mono : MonoBehaviour
    {

        private void Start()
		{
            this._player = base.GetComponentInParent<Player>();

            this.isLow = false;
            this.punish = 5;
            this.damage = 15;
        }
		private void Update()
        {
            if (this._player.data.block.sinceBlock > this._player.data.block.Cooldown())
            {
                this.lastblocks = 0;
            }

            if (this._player.data.block.IsOnCD() && this._player.data.health >= (this.damage + this.lastblocks * this.punish))
            {
                

                if (this.isLow == true)
                {
                    this._player.data.block.ResetCD(true);
                    this.isLow = false;
                }
                else
                {
                    this._player.data.healthHandler.TakeDamage(Vector2.up * (this.damage + this.lastblocks * this.punish) , this._player.data.block.blockedAtPos, null, null, false, true);

                    foreach (Player pl in PlayerManager.instance.players)
                    { 
                        pl.GetComponent<SoundManager_Mono>().PlaySound(VarietyCards.chompSound,1.25f,0.75f,0.05f);
                    }


                    this._player.data.block.ResetCD(false);
                    this.isLow = false;
                    this.lastblocks++;
                }



            }
            else if(this._player.data.health < (this.damage + this.lastblocks * this.punish))
            {

                this._player.data.block.counter = 0;
                this.isLow = true;

            }
            else if(!this._player.data.block.IsOnCD())
            {
                this.isLow = false;
            }
            
        }
   
        private Player _player;

        private int damage;
        private int punish;
        private bool isLow;
        private int lastblocks;

    }
}
