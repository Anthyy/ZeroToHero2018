using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Scroll : MonoBehaviour
    {       
        private Rigidbody2D rBody; // This is creating an 'rBody' field for the object in the inspector

        // Use this for initialization
        void Start()
        {
            rBody = GetComponent<Rigidbody2D>(); 
            rBody.velocity = new Vector2(GameManager.Instance.scrollSpeed, 0);
        }

        // Update is called once per frame
        void Update()
        {
            // Check if the game is over
            if (GameManager.Instance.gameOver)
            {
                // Reset velocity to zero
                rBody.velocity = Vector2.zero;
            }
        }
    } 
}
