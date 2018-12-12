﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Player : MonoBehaviour
    {
        public float upForce = 6f; // Upward force of the Flap

        private bool isDead = false; // Has the player died?
        private Rigidbody2D rBody;

        // Use this for initialization
        void Start()
        {
            rBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Fly
                Flap();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // Cancel velocity
            rBody.velocity = Vector2.zero;
            // Bird is now dead
            isDead = true;
            // Tell the GameManager about it
            GameManager.Instance.gameOver = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // If other is column
            if(other.name.Contains("Column"))
            {
                // Add 1 to score
                GameManager.Instance.AddScore(1);
            }
        }
        // Make the bird fly 
        void Flap()
        {
            // If the player isn't dead
            if(isDead == false) // or if(!isDead)
            {
                // Set velocity of bird to up force
                rBody.velocity = Vector2.up * upForce;
            }
        }
    } 
}
