﻿using System;
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

            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.audioClip[0] = VarietyCards.chompSound;
            soundContainer.setting.volumeIntensityEnable = true;
            chomp = ScriptableObject.CreateInstance<SoundEvent>();  
            chomp.soundContainerArray[0] = soundContainer;
        }
		private void Update()
        {

            if(this._player.data.block.IsOnCD() && this._player.data.health >= 20)
            {
                this._player.data.healthHandler.TakeDamage(Vector2.up * 15, this._player.data.block.blockedAtPos, null, null, false, true);

                SoundManager.Instance.Play(this.chomp,base.transform, new SoundParameterBase[] 
                {
                    new SoundParameterIntensity(Optionshandler.vol_Master * Optionshandler.vol_Sfx * 1.5f),
                    new SoundParameterPitchRatio((float)new System.Random().NextDouble()+0.75f)
                });

                this._player.data.block.ResetCD(false);

                

            }
            else if(this._player.data.health < 20)
            {

                this._player.data.block.counter = 0;

            }
        }
   
        private Player _player;
        private SoundEvent chomp;

    }
}