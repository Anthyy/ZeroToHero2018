using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq; // Allows you to use Last()

namespace Snake
{
    public class Player : MonoBehaviour
    {
        public float moveRate = .3f; // Movement interval (in seconds)
        public float sprintRate = .1f; // Sprint interval
        public float keyDownDuration = 1f; // How long does a key have to be down before sprinting?
        public GameObject tailPrefab; // Prefab of tail to spawn
        public Vector2 direction = Vector3.right; // Movement direction of snake (Right by default)

        private float keyDownTimer = 0f; // How long has any key been pressed?
        private float moveTimer = 0f; // Timer to keep track of elapsed time
        private float interval = 0f; // Store the move rate / sprint rate
        private bool hasEaten = false; // Has the snake eaten?
        private List<Transform> tail = new List<Transform>(); // List to keep track of tails

        // Add to the tail along with desired gap distance
        void AppendTail(Vector3 gapPos)
        {
            // Load prefab into the world
            GameObject clone = Instantiate(tailPrefab, gapPos, Quaternion.identity);
            // Add to the tail by inserting to start of list
            tail.Insert(0, clone.transform);
            // Reset the has eaten flag
            hasEaten = false;
        }

        // Update positions of the tail list
        void RefreshTail(Vector3 gapPos)
        {
            // Do we have a tail?
            if (tail.Count > 0)
            {
                // Move the last tail element to where the Head's old position was
                tail.Last().position = gapPos;
                // Add to front of list, remove from back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }

        void Move()
        {
            // Save current position
            Vector2 gapPos = transform.position;
            // Move the head into the new direction
            transform.Translate(direction);
            // Has the snake eaten something? 
            if (hasEaten)
            {
                // Append size of the tail
                AppendTail(gapPos);
            }
            else
            {
                // Refresh tail location
                RefreshTail(gapPos);
            }
        }

        private void Start()
        {
            // Set initial interval delay
            interval = moveRate;
        }
        // Update is called once per frame
        void Update()
        {
            // Count up the timer
            moveTimer += Time.deltaTime;
            // Is it time to move?
            if(moveTimer >= interval)
            {
                Move(); // Move the snake
                moveTimer = 0f; // Reset timer
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // If collided with Food
            if (other.name.Contains("Food"))
            {
                // Increase size of player
                hasEaten = true;
                // Remove the food
                Destroy(other.gameObject);
                // Tell GameManager to spawn Food
                GameManager.Instance.Spawn();
                // Tell GameManager we scored
                GameManager.Instance.AddScore(1);
            }
            else // Hit something else?
            {
                // Game Over
                GameManager.Instance.RestartGame();
            }           
        }

        public void Sprint()
        {
            // Count how long a key is down for
            keyDownTimer += Time.deltaTime;
            // If key has been down for a set amount of time (duration)
            if (keyDownTimer >= keyDownDuration)
            {
                // Snake is now running
                interval = sprintRate;
            }
        }

        public void Walk()
        {
            // Reset the keydown timer
            keyDownTimer = 0f;
            // Reset the move speed
            interval = moveRate;
        }
    }
}
