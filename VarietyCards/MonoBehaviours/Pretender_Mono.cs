using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnityEngine;
using Photon.Pun;

namespace VarietyCards.MonoBehaviours
{
    internal class Pretender_Mono : MonoBehaviour
    {
		private void Start()
		{
		
            this._player = base.GetComponent<Player>();



        }
		private void Update()
        {

            
            if(_player.data.health > _player.data.maxHealth/2)
            {

                _player.data.health = _player.data.maxHealth/2;

            }

        }


        private Player _player;
       

    }
}
