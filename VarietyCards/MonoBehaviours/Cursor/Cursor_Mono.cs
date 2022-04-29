using UnityEngine;

namespace VarietyCards.MonoBehaviours.Cursor
{
    internal class Cursor_Mono : MonoBehaviour
    {

        private void Start()
        {
            this.timee = 0;
        }
        public void Destroy()
        {
            UnityEngine.Object.Destroy(this.target);
            UnityEngine.Object.Destroy(this.holding);
            UnityEngine.Object.Destroy(this.parent);
        }
        public void Update()
        {
            this.timee += Time.deltaTime;
            this.seconds = (this.timee % 60);

            if (this.clicking)
            {

                this.parent.transform.position = Vector3.MoveTowards(this.parent.transform.position, this.target.transform.position, 5 * Time.deltaTime);
                if (this.parent.transform.position == this.target.transform.position)
                {
                    this.clicking = false;
                    this.returning = true;
                    this.owner.data.healthHandler.Heal(5);
                }
            }
            else if (this.returning)
            {

                this.parent.transform.position = Vector3.MoveTowards(this.parent.transform.position, this.holding.transform.position, 5 * Time.deltaTime);
                if (this.parent.transform.position == this.holding.transform.position)
                {
                    this.clicking = false;
                    this.returning = false;
                }
            }
            else
            {
                this.parent.transform.position = this.holding.transform.position;
                this.parent.transform.rotation = this.holding.transform.rotation;
            }


            if (this.seconds >= 10 + this.delay)
            {
                this.Click();
                this.delay=0;
            }
        }
        public void Click()
        {
            this.timee = 0;
            this.clicking = true;

        }

        private float timee;
        public float seconds;
        private bool clicking;
        private bool returning;
        public GameObject parent;
        public GameObject holding;
        public GameObject target;
        public float delay;
        public Player owner;


    }
}
