using System;
using System.Collections.Generic;
using Assets.Code.Structure;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Assets.Code
{
    /// <inheritdoc><cref></cref>
    /// </inheritdoc>
    /// <summary>
    /// Manager class for spawning and tracking all of the game's asteroids
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AsteroidManager : MonoBehaviour, ISaveLoad
    {
        private const float SpawnTime = 3f;
        private const int MaxAsteroidCount = 8;
        private static Object _asteroidPrefab;
        private float _lastspawn;
        private Transform _holder;

        // ReSharper disable once UnusedMember.Global
        internal void Start () {
            _asteroidPrefab = Resources.Load("Asteroid");
            _holder = transform;
            Asteroid.Manager = this;
        }

        // ReSharper disable once UnusedMember.Global
        internal void Update () {
            if ((Time.time - _lastspawn) < SpawnTime) return;
            _lastspawn = Time.time;
            Spawn();
        }

        private void Spawn () {
            if (_holder.childCount >= MaxAsteroidCount) { return; }

            var pos = BoundsChecker.GetRandomPos();
            var vel = BoundsChecker.GetRandomVelocity();
            int size = Random.Range(2, Asteroid.AsteroidTypes); // don't spawn tinies

            ForceSpawn(pos, vel, size);
        }

        public void ForceSpawn (Vector2 pos, Vector2 velocity, int size, Quaternion rotation = new Quaternion())
        {
            GameObject newAsteroid = Object.Instantiate(_asteroidPrefab, pos, rotation) as GameObject;
            newAsteroid.transform.parent = _holder.transform;
            Asteroid test = newAsteroid.GetComponent<Asteroid>();
            test.Initialize(velocity, size);


        }

        #region saveload

        // TODO fill me in
        public GameData OnSave ()
        {
            Asteroid[] asteroids = Object.FindObjectsOfType(typeof(Asteroid)) as Asteroid[];
            AsteroidsData theSave = new AsteroidsData();


            foreach (Asteroid asteroid in asteroids)
            {

                //grab the rigidbody2d component from the current bullet
                Rigidbody2D temp_asteroid = asteroid.GetComponent<Rigidbody2D>();

                //make a new datapoint for this bullet
                AsteroidData one_asteroid = new AsteroidData();


                one_asteroid.Size = asteroid.Size;
                one_asteroid.Pos = temp_asteroid.position;
                one_asteroid.Velocity = temp_asteroid.velocity;


                //append this to list of all datapoints
                theSave.Asteroids.Add(one_asteroid);
            }
            return theSave;
        }

        
        public void OnLoad (GameData data) {
            Asteroid[] asteroids = Object.FindObjectsOfType(typeof(Asteroid)) as Asteroid[];

            //get rid of all current asteroids
            foreach (Asteroid asteroid in asteroids)
            {
                Destroy(asteroid.gameObject);
            }

            AsteroidsData load_data = data as AsteroidsData;
            List<AsteroidData> asteroid_data = load_data.Asteroids;

            foreach (AsteroidData ast_data in asteroid_data)
            {
                ForceSpawn(ast_data.Pos, ast_data.Velocity, ast_data.Size);
            }
        }

        #endregion
    }

    /// <summary>
    /// The save data for all the asteroids
    /// </summary>
    public class AsteroidsData : GameData
    {
        public List<AsteroidData> Asteroids = new List<AsteroidData>();
    }

    /// <summary>
    /// The save data for one asteroid
    /// </summary>
    public class AsteroidData
    {
        public int Size;
        public Vector2 Pos;
        public Vector2 Velocity;
    }
}
