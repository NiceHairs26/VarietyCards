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
            this._player = this.monoHold.GetComponentInParent<Player>();

            this.center = new GameObject("Center");
            this.center.transform.SetParent(this.monoHold.transform);
            this.center.transform.localPosition = new Vector3(0f, 0f, 10f);

            this.amount = 0;
            this.cursors = new ArrayList();
            this.targets = new ArrayList();
            this.holdings = new ArrayList();

        }
		private void Update()
        {
            this.timer = 20 * Time.deltaTime;
            this.center.transform.RotateAround(this._player.gameObject.transform.position,Vector3.forward,timer);
        }
        public void Add(int plus)
        {

            this.center.transform.rotation.Set(0, 0, 0, 0);

                foreach (GameObject cursor in this.cursors)
                {
                    UnityEngine.Object.Destroy(cursor);
                }
                this.cursors.Clear();
                foreach (GameObject target in this.targets)
                {
                    UnityEngine.Object.Destroy(target);
                }
                this.targets.Clear();
                foreach (GameObject holding in this.holdings)
                {
                    UnityEngine.Object.Destroy(holding);
                }
                this.holdings.Clear();

            this.amount += plus;

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

                GameObject holder = new GameObject();
                holder.transform.SetParent(this.center.transform);
                holder.transform.position =spawnPos;

               

                GameObject target = new GameObject();
                target.transform.SetParent(this.center.transform);
                Vector3 targetPos = this.center.transform.position + spawnDir * (distance - 0.5f);
                target.transform.position = targetPos;

                GameObject cursor = Instantiate(VarietyCards.cursor, spawnPos, Quaternion.Euler(0, 180, 0)); 
                cursor.transform.SetParent(holder.transform);

               

                Vector3 norTar = (this.center.transform.position - cursor.transform.position).normalized;
                float angle = Mathf.Atan2(norTar.x, norTar.y) * Mathf.Rad2Deg;
                Quaternion rotation = new Quaternion();
                rotation.eulerAngles = new Vector3(0, 180, angle);

                holder.transform.rotation = rotation;
                cursor.transform.rotation = rotation;



                Cursor_Mono cum = cursor.AddComponent<Cursor_Mono>();
                cum.parent = cursor;
                cum.target = target;
                cum.holding = holder;
                cum.owner = this._player;

                this.cursors.Add(cum);
                this.targets.Add(target);
                this.holdings.Add(holder);
            }
        }


        private Player _player;

        private ArrayList cursors;
        private ArrayList targets;
        private ArrayList holdings;

        private GameObject center;
        private int amount;
        public float timer;

        public GameObject monoHold;
    }
}
