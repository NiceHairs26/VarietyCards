using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnityEngine;

namespace VarietyCards.MonoBehaviours
{
    internal class AutoBlock_Mono : MonoBehaviour
    {
		private void Start()
		{


            this._player = base.GetComponentInParent<Player>();

        }
		private void Update()
        {
            if(this._player.data.isPlaying && !this._player.data.dead && this._player.data.block.sinceBlock > 0.1f)
            {
                this._player.data.block.TryBlock();
            }
            


        }

        public Player _player;
       

    }
}
