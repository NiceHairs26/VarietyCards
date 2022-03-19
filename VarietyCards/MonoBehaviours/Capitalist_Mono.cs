using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using HarmonyLib;
using UnityEngine;

namespace VarietyCards.MonoBehaviours
{
    internal class Capitalist_Mono : MonoBehaviour
    {


        private void Start()
        {

            this._player = base.GetComponent<Player>();


        }
        private void Update()
        {


        }

        public void Heal(float healAmount)
        {

            this._player.data.health += healAmount * 0.1f;
            this._player.data.health = Mathf.Clamp(this._player.data.health, float.NegativeInfinity, this._player.data.maxHealth);

        }


        private Player _player;




    }
}
