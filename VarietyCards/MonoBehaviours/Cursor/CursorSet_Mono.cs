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
    internal class CursorSet_Mono : MonoBehaviour
    {

        private void Start()
		{
            this._player = base.GetComponent<Player>();

            this.center = new GameObject("Center");
            this.center.transform.SetParent(this._player.transform);
            this.center.transform.localPosition = new Vector3(0f, 0f, 10f);

            this.amount = 0;
            this.cursors = new ArrayList();

        }
		private void Update()
        {
            this.timer = 20 * Time.deltaTime;
            //this.center.transform.RotateAround(this._player.gameObject.transform.position,Vector3.forward,timer);
        }
        public void Add(int plus)
        {
            Quaternion centerRotation = this.center.transform.rotation;
            this.center.transform.rotation.Set(0, 0, 0, 0);

            this.amount += plus;
            if(this.cursors.Count > 0)
            {
                foreach (GameObject cursor in this.cursors)
                {
                    UnityEngine.Object.Destroy(cursor);
                }
                this.cursors.Clear();
            }
            

            for (int i = 0; i < this.amount; i++)
            {
                float distance;
                int amount;
                if (i<=10)
                {
                    distance = 1.5f;
                    amount = 10;
                }
                else if (i <= 25)
                {
                    distance = 2f;
                    amount = 15;
                } 
                else
                {
                    distance = 2.5f;
                    amount = 20;
                }

                float radians =i * 2 * Mathf.PI / amount;

                float vertical = Mathf.Sin(radians);
                float horizontal = Mathf.Cos(radians);

                Vector3 spawnDir = new Vector3(horizontal, vertical, 0);

                Vector3 spawnPos = this.center.transform.position + spawnDir * distance;

                GameObject cursor = Instantiate(VarietyCards.cursor, spawnPos, Quaternion.Euler(0, 180, 0)); ;
                cursor.transform.SetParent(this.center.transform);

                Vector3 norTar = (this.center.transform.position - cursor.transform.position).normalized;
                float angle = Mathf.Atan2(norTar.x, norTar.y) * Mathf.Rad2Deg;
                Quaternion rotation = new Quaternion();
                rotation.eulerAngles = new Vector3(0, 180, angle);
                cursor.transform.rotation = rotation;

                this.center.transform.rotation = centerRotation;

                this.cursors.Add(cursor);
                Cursor_Mono cum = cursor.AddComponent<Cursor_Mono>();
                cum.parent = cursor;
                cum.center = this.center;
                cum.spawnDir = spawnDir;
                cum.distance = distance;
            }
        }


        private Player _player;

        private ArrayList cursors;
        private GameObject center;
        private int amount;
        public float timer;

    }
}
