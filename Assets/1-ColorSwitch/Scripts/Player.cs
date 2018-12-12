using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    //[RequireComponent(typeof(Rigidbody2D))] // To get a component automatically for a game object
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;
        public Rigidbody2D rBody;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;

        private Color currentColor;
        // Use this for initialization
        void Start()
        {
            // Search the game object this script is attached to for a RigidBody2D component
            rBody = GetComponent<Rigidbody2D>(); // You can do this instead of drag & dropping the Rigidbody 2D component into the 'R Body' section in the player script in the inspector.

            // Randomise the player's colour
            RandomizeColor();
        }

        // Update is called once per frame
        void Update()
        {
            // If jump button is pressed
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) // or if (Input.GetKeyDown(KeyCode.Space))
            {
                // Add force up
                rBody.velocity = Vector2.up * jumpForce;
            }

        }

        // OnTriggerEnter2D is called when the Collider2D other enters the trigger (2D physics only)
        private void OnTriggerEnter2D(Collider2D other)
        {
            // If other is "ColorChanger" 
            if(other.name /* Can also use .tag/compareTag */ == "ColorChanger")
            {
                // Randomize color
                RandomizeColor();
                // Destroy other (color changer)
                Destroy(other.gameObject);
                // Exit the function (return) 
                return;
            }

            // Get SpriteRenderer from other object
            SpriteRenderer otherRend = other.GetComponent<SpriteRenderer>();

            // If there is a SpriteRenderer component on other collider
            if(otherRend != null)
            {
                // If other colour is not player's colour 
                if(otherRend.color != rend.color)
                {
                    print("Game is over!");
                    // Game is over!
                    onGameOver.Invoke();
                }
            }

        }



        // Set the Player to a random colour
        void RandomizeColor()
        {
            // Generate random index
            int index = Random.Range(0, colors.Length); // where 'Length' = total amount
            // Set color to random color
            rend.color = colors[index];
        }
    }
}

