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
    internal class SetCursor_Mono : RayHitEffect
    {

		private void Start()
		{
		}
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this);
		}
		public override HasToReturn DoHitEffect(HitInfo hit)
		{
			return HasToReturn.canContinue;
		}
	}
}
