using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Assets.Structure;

public class BulletManager
{
    private readonly Transform _holder;

    /// <summary>
    /// Bullet prefab. Use GameObject.Instantiate with this to make a new bullet.
    /// </summary>
    private readonly Object _bullet;

    public BulletManager(Transform holder)
    {
        _holder = holder;
        _bullet = Resources.Load("Bullet");
    }

    // TODO fill me in
    public void ForceSpawn(Vector2 pos, Quaternion rotation, Vector2 velocity, float deathtime)
    {
        var newbullet = (GameObject)Object.Instantiate(_bullet, pos, rotation);
        newbullet.GetComponent<Bullet>().Initialize(velocity, deathtime);
        newbullet.transform.SetParent(_holder);

    }

    /// <summary>
    /// Save data for all bullets in game
    /// </summary>
    public class BulletsData // : GameData ??????
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


//public class BulletManager1 : MonoBehaviour {
//    // public List<BulletManager1> bullets = new List<BulletManager1>();

//	// Use this for initialization
//	void Start () {

//	}

//	// Update is called once per frame
//	void Update () {

//	}
//}
