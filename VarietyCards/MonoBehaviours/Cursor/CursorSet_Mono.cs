using System;
using System.Collections;
using UnityEngine;

namespace VarietyCards.MonoBehaviours.Cursor
{
    internal class CursorSet_Mono : MonoBehaviour
    {

        private void Awake()
        {
            this.setup = false;
        }

        public void Setup(Player player)
        {
            try
            {
                if (!setup)
                {
                    this._player = player;
                    this.center = new GameObject("Center");
                    this.center.transform.SetParent(this._player.gameObject.transform);
                    this._player.data.stats.objectsAddedToPlayer.Add(this.center);
                    this.center.transform.localPosition = new Vector3(0f, 0f, 10f);

                    this.amount = 0;
                    this.cursors = new ArrayList();
                    this.setup = true;

                }

            }
            catch (Exception ex) { UnityEngine.Debug.Log($"Setup Failed. Exception: {ex}"); }


        }
        private void Update()
        {

            this.timer = 20 * Time.deltaTime;
            this.center.transform.RotateAround(this._player.gameObject.transform.position, Vector3.forward, timer);

        }
        public void Add(int plus)
        {
            if (setup)
            {
                this.center.transform.rotation.Set(0, 0, 0, 0);
                try
                {
                    


                    foreach (Cursor_Mono cursor in this.cursors)
                    {
                        cursor.Destroy();
                    }



                }
                catch (Exception ex) { UnityEngine.Debug.Log($"Curser Reset Failed. Exception: {ex}"); }

                try
                {
                    this.delay = 0;
                    this.amount += plus;


                    for (int i = 0; i < this.amount; i++)
                    {
                        float distance;
                        int amount;
                        delay += 0.25f;
                        if (i <= 10)
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
                        if(this.delay>30)
                        {
                            this.delay=0;
                        }


                        float radians = i * 2 * Mathf.PI / amount;

                        float vertical = Mathf.Sin(radians);
                        float horizontal = Mathf.Cos(radians);

                        Vector3 spawnDir = new Vector3(horizontal, vertical, 0);

                        Vector3 spawnPos = this.center.transform.position + spawnDir * distance;

                        GameObject holder = new GameObject();
                        holder.transform.SetParent(this.center.transform);
                        holder.transform.position = spawnPos;



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

                        try
                        {

                            Cursor_Mono cum = cursor.AddComponent<Cursor_Mono>();
                            cum.transform.parent = cursor.transform;
                            cum.parent = cursor;
                            cum.target = target;
                            cum.holding = holder;
                            cum.owner = this._player;
                            cum.delay = delay;
                            this.cursors.Add(cum);

                        }
                        catch (Exception ex) { UnityEngine.Debug.Log($"Curser_Mono Init Failed. Exception: {ex}"); }
                    }

                }
                catch (Exception ex) { UnityEngine.Debug.Log($"Curser Spawn Failed. Exception: {ex}"); }

            }
        }


        private Player _player;

        private ArrayList cursors;
        private bool setup;

        private GameObject center;
        private int amount;
        private float timer;
        private float delay;

    }
}
