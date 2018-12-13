using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class InputController : MonoBehaviour
    {
        public Player player;

        // Update is called once per frame
        void Update()
        {
            CheckSprint();
            CheckMove();
        }

        // Check if the player is sprinting
        void CheckSprint()
        {
            // If any key is pressed
            if (Input.anyKey)
            {
                // Sprint
                player.Sprint();
            }
            else
            {
                // Walk
                player.Walk();
            }
        }

        // Check if the player is moving
        void CheckMove()
        {
            // Modify Direction
            if (Input.GetKey(KeyCode.RightArrow) && !player.direction.Equals(Vector2.left))
                player.direction = Vector2.right;  // C# allows you to have 1 statement under an if statement, so you don't need the scope unless you have more than 1          
            else if (Input.GetKey(KeyCode.DownArrow) && !player.direction.Equals(Vector2.up))
                player.direction = Vector2.down;
            else if (Input.GetKey(KeyCode.LeftArrow) && !player.direction.Equals(Vector2.right))
                player.direction = Vector2.left;
            else if (Input.GetKey(KeyCode.UpArrow) && !player.direction.Equals(Vector2.down))
                player.direction = Vector2.up;
        }
    } 
}
