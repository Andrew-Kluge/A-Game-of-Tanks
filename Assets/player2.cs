﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Code
{
    public class player2 : MonoBehaviour
    {

        public float TurnVar;
        private static string _fireaxis;

        private Rigidbody2D _rb;
        //private Gun _gun;

        // ReSharper disable once UnusedMember.Global
        internal void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            //_gun = GetComponent<Gun>();

            _fireaxis = Platform.GetFireAxis();
        }

        // ReSharper disable once UnusedMember.Global
        internal void Update()
        {
            HandleInput();
        }

        /// <summary>
        /// Check the controller for player inputs and respond accordingly.
        /// </summary>
        private void HandleInput()
        {
            //Sideways action
            TurnVar = Input.GetAxis("Horizontal2");
            Turn(Input.GetAxis("Horizontal2"));

            //Forwards & Backwards Action
            Thrust(Input.GetAxis("Vertical2"));

            //Firing action
            /*if (Input.GetAxis(_fireaxis) > 0)
            {
                Fire();
            }*/
        }

        private void Turn(float direction)
        {
            if (Mathf.Abs(direction) < 0.02f)
            {
                return;
            }
            _rb.AddTorque(direction * -0.05f);
        }

        private void Thrust(float intensity)
        {
            if (Mathf.Abs(intensity) < 0.02f)
            {
                return;
            }
            _rb.AddRelativeForce(Vector2.up * intensity);
        }

        /*private void Fire () {
            _gun.Fire();
        }*/
        /*
        public class PlayerGameData : GameData
        {
            public Vector2 Pos;
            public Vector2 Velocity;
            public float Rotation;
            public float AngularVelocity; // reaed as DEGREES but stored as RADIANS; COME ON UNITY
        }*/
    }
}

