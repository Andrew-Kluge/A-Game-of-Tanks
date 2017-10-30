using System.Collections;
using System.Collections.Generic;
using Assets.Code.Structure;
using UnityEngine;


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
            Debug.Log("fired a bullet");
            /// TODO - Import BulletManager1 ///
            Game.Bullets.ForceSpawn(
                transform.position + transform.up * 0.7f,
                transform.rotation,
                transform.up * 4f,
                time + Bullet.Lifetime);

        }
    }
}

