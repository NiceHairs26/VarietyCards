using Sonigon;
using UnityEngine;

namespace VarietyCards.MonoBehaviours
{
    internal class Capitalist_Mono : MonoBehaviour
    {


        private void Start()
        {

            this._player = base.GetComponentInParent<Player>();


        }
        private void Update()
        {
        }

        public void Heal(float healAmount)
        {

            if (healAmount * 0.1f < 1)
            {
                return;
            }
            SoundManager.Instance.Play(this._player.data.healthHandler.soundHeal, base.transform);
            this._player.data.health += healAmount * 0.1f;
            this._player.data.healthHandler.Heal(healAmount * 0.1f);
            this._player.data.health = Mathf.Clamp(this._player.data.health, float.NegativeInfinity, this._player.data.maxHealth);
            this._player.data.healthHandler.healPart.Emit((int)Mathf.Clamp(healAmount * 0.2f, 1f, 10f));

        }


        private Player _player;



    }
}
