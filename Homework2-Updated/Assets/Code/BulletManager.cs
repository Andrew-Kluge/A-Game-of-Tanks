using System;
using System.Collections.Generic;
using Assets.Code.Structure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    /// <summary>
    /// Bullet manager for spawning and tracking all of the game's bullets
    /// </summary>
    public class BulletManager : ISaveLoad
    {
        private readonly Transform _holder;

        /// <summary>
        /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
        /// </summary>
        private readonly Object _bullet;

        public BulletManager (Transform holder) {
            _holder = holder;
            _bullet = Resources.Load("Bullet");
        }

        // TODO fill me in
        public void ForceSpawn (Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime)
        {
            
            GameObject newBullet = Object.Instantiate(_bullet, pos, rotation) as GameObject;
            newBullet.transform.parent = _holder.transform;
            Bullet test = newBullet.GetComponent<Bullet>();
            test.Initialize(velocity, deathtime);
        }

        #region saveload

        // TODO fill me in
        public GameData OnSave ()
        {
            Bullet[] bullets = (Bullet[]) Object.FindObjectsOfType(typeof(Bullet));
            BulletsData theSave = new BulletsData();
            List<BulletData> temp_list = new List<BulletData>();
            

            foreach (Bullet bullet in bullets)
            {

                //grab the rigidbody2d component from the current bullet
                Rigidbody2D temp_bullet = bullet.GetComponent<Rigidbody2D>();

                //make a new datapoint for this bullet
                BulletData one_bullet = new BulletData();
                one_bullet.Pos = temp_bullet.position;
                one_bullet.Velocity = temp_bullet.velocity;
                one_bullet.Rotation = temp_bullet.rotation;


                //append this to list of all datapoints
                temp_list.Add(one_bullet);
            }
            theSave.Bullets = temp_list;
            return theSave;
        }

        // TODO fill me in
        public void OnLoad (GameData data) {

            //first get rid of all current bullets
            Bullet[] bullets = Object.FindObjectsOfType(typeof(Bullet)) as Bullet[];

            foreach (Bullet bullet in bullets)
            {
                UnityEngine.Object.Destroy(bullet.gameObject);
            }

            //now load all bullets and instantiate them
            BulletsData bulls_data = data as BulletsData;
            List<BulletData> bulls_data_list = bulls_data.Bullets; 

            foreach (BulletData bull_data_pt in bulls_data_list)
            {
                ForceSpawn(bull_data_pt.Pos, Quaternion.Euler(0,0, bull_data_pt.Rotation), bull_data_pt.Velocity, Time.time + Bullet.Lifetime);
            }


        }

        #endregion

    }

    /// <summary>
    /// Save data for all bullets in game
    /// </summary>
    public class BulletsData : GameData
    {
        public List<BulletData> Bullets;
    }

    /// <summary>
    /// Save data for a single bullet
    /// </summary>
    public class BulletData
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public float Rotation;
    }
}