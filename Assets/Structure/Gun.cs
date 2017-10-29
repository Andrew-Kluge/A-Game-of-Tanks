using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//  using BulletManager1;

namespace Assets.Structure
{
    public class Gun : MonoBehaviour
    {
        private const float FireCooldown = 1f;
        private float _lastfire;

        public void Fire()
        {
            float time = Time.time;
            if (time < _lastfire + FireCooldown) { return; }

            _lastfire = time;
            /// TODO - Impot BulletManager1 ///
            //ForceSpawn(
            //    transform.position + transform.up * 0.7f,
            //    transform.rotation,
            //    transform.up * 4f,
            //    time + Bullet.Lifetime);

            //Bullets.ForceSpawn(
            //    transform.position + transform.up * 0.7f,
            //    transform.rotation,
            //    transform.up * 4f,
            //    time + Bullet.Lifetime);
        }
    }
}

