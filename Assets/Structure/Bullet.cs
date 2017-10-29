using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Structure
{
    public class Bullet : MonoBehaviour
    {
        public const float Lifetime = 7.5f;
        private float _deathtime;

        public void Initialize(Vector2 velocity, float deathtime)
        {
            GetComponent<Rigidbody2D>().velocity = velocity;
            _deathtime = deathtime;
        }

        internal void Update()
        {
            if(Time.time > _deathtime)
            {
                Die();
            }
        }

        internal void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }

    }
}