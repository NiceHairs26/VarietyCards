using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnboundLib;
using UnityEngine;
using Sonigon;
using Sonigon.Internal;

namespace VarietyCards.MonoBehaviours.Cursor
{
    internal class Cursor_Mono : MonoBehaviour
    {

		private void Start()
		{
			this.timee = 0;
		}
		public void Update()
		{
			this.timee += Time.deltaTime;
			this.seconds = (int)(this.timee % 60);

			if(this.clicking)
            {

				Vector3 targetPos = this.center.transform.position + this.spawnDir * (this.distance-0.5f);

				parent.transform.position = Vector3.MoveTowards(parent.transform.position, targetPos, 10 * Time.deltaTime);
				if(parent.transform.position==target)
				{ 
					this.clicking = false;
					this.returning = true;
				}
			}
			else if(this.returning)
            {
				Vector3 targetPos = this.center.transform.position + this.spawnDir * this.distance;

				parent.transform.position = Vector3.MoveTowards(parent.transform.position, targetPos, 10 * Time.deltaTime);
				if (parent.transform.position == oldPos)
				{
					this.clicking = false;
					this.returning = false;
				}
			}

			

			if (this.seconds >= 3)
            {
				this.Click();
			}
		}
		private void Click()
        {
			this.timee = 0;
			this.oldPos = parent.transform.position;
			this.clicking = true;

		}
		private float timee;
		private int seconds;
		private bool clicking;
		private bool returning;
		private Vector3 target;
		private Vector3 oldPos;
		public GameObject parent;
		public GameObject center;

		public Vector3 spawnDir;
		public float distance;
	}
}
