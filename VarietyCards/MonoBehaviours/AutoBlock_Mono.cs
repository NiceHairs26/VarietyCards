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
		
            this._player = base.GetComponent<Player>();


        }
		private void Update()
        {

            this._player.data.block.TryBlock();


        }

        private Player _player;
       

    }
}
