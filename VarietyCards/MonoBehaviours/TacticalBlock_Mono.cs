using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnityEngine;

namespace VarietyCards.MonoBehaviours
{
    internal class TacticalBlock_Mono : MonoBehaviour
    {
        private Boolean reloading = false;
        private void Start()
		{

            this._gun = base.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this._player = base.GetComponent<Player>();


        }
		private void Update()
        {
            if(this._gun.isReloading && reloading == false)
            { 
                reloading = true;
                this._player.data.block.ResetCD(true);



            }
            else if(this._gun.isReloading == false && reloading)
            {
                reloading = false;
            }
            


        }


        private Gun _gun;
        private Player _player;
    }
}
