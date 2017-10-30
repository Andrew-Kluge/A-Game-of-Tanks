using System;
using Assets.Code.Structure;
using UnityEngine;

namespace Assets.Code
{
    /// <summary>
    /// Player controller class
    /// </summary>
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Player : MonoBehaviour, ISaveLoad
    {
        public float TurnVar;
        public bool isPlayer1 = true;
        public string _fireaxis;
        //public string _fireaxis2;
        private Rigidbody2D _rb;
        private Gun _gun;

        // ReSharper disable once UnusedMember.Global
        internal void Start () {
            _rb = GetComponent<Rigidbody2D>();
            _gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis(isPlayer1);
            //_fireaxis2 = Platform.GetFireAxis(isPlayer1);
        }

        // ReSharper disable once UnusedMember.Global
        internal void Update () {
            HandleInput();
        }

        internal void OnCollisionEnter2D(Collision2D other)
        {
            
        }

        /// <summary>
        /// Check the controller for player inputs and respond accordingly.
        /// </summary>
        private void HandleInput () {

            if (isPlayer1)
            {
                //Sideways action
                TurnVar = Input.GetAxis("Horizontal");
                Turn(Input.GetAxis("Horizontal"));

                //Forwards & Backwards Action
                Thrust(Input.GetAxis("Vertical"));

                //Firing action
                if (Input.GetAxis(_fireaxis) > 0)
                {
                    Fire();
                }
            }
            else
            {
                //Sideways action
                TurnVar = Input.GetAxis("Horizontal2");
                Turn(Input.GetAxis("Horizontal2"));

                //Forwards & Backwards Action
                Thrust(Input.GetAxis("Vertical2"));

                //Firing action
                if (Input.GetAxis(_fireaxis) > 0)
                {
                    Fire();
                }
            }



        }

        private void Turn (float direction) {
            if (Mathf.Abs(direction) < 0.02f) { return; }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust (float intensity) {
            if (Mathf.Abs(intensity) < 0.02f) { return; }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        private void Fire () {
            _gun.Fire();
        }

        #region saveload
        
        public GameData OnSave ()
        {
            PlayerGameData saveState = new PlayerGameData();
            saveState.Pos = _rb.position;
            saveState.Velocity = _rb.velocity;
            saveState.Rotation = _rb.rotation;
            saveState.AngularVelocity = _rb.angularVelocity;

            return saveState;
        }

        public void OnLoad (GameData data)
        {
            PlayerGameData loadState = (PlayerGameData)data;
            _rb.position = loadState.Pos;
            _rb.velocity = loadState.Velocity;
            _rb.rotation = loadState.Rotation;
            
            //lab instructions say to multiply this by Mathf.Deg2Rad but this works without, so leaving it without
            _rb.angularVelocity = loadState.AngularVelocity;
        }
        
        #endregion
    }

    public class PlayerGameData : GameData
    {
        public Vector2 Pos;
        public Vector2 Velocity;
        public float Rotation;
        public float AngularVelocity; // reaed as DEGREES but stored as RADIANS; COME ON UNITY
    }
}
