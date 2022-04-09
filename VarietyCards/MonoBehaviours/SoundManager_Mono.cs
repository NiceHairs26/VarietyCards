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
    internal class SoundManager_Mono : MonoBehaviour
    {
        public void PlaySound(AudioClip audio, float volume = 1, float randpitch = 1, float delay = 0)
        {
            SoundContainer soundContainer = ScriptableObject.CreateInstance<SoundContainer>();
            soundContainer.audioClip[0] = audio;
            soundContainer.setting.volumeIntensityEnable = true;
            sound = ScriptableObject.CreateInstance<SoundEvent>();
            sound.soundContainerArray[0] = soundContainer;

            if (sound)
            {
                SoundManager.Instance.Play(this.sound, base.transform, new SoundParameterBase[]
                {
                            new SoundParameterIntensity(Optionshandler.vol_Master * Optionshandler.vol_Sfx * volume),
                            new SoundParameterPitchRatio((float)new System.Random().NextDouble()+randpitch),
                            new SoundParameterDelay(delay)
                });
            }
        }
        private SoundEvent sound;
    }
}
