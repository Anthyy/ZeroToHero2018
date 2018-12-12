using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AngryAliens
{
    public class Ball : MonoBehaviour
    {
        public float releaseTime = 0.15f;
        public float maxDragDistance = 2f;
        public float stoppingVelocity = .05f; // Velocity to detect stopping
        public Rigidbody2D ball, anchor;
        public SpringJoint2D spring;

        private bool isPressed = false;
        private bool isReleased = false;

        // Update is called once per frame
        void Update()
        {
            // If the ball has been released
            if (isReleased)
            {
                #region Detect Velocity
                // If ball's velocity magnitude is less than stopping velocity
                if (ball.velocity.magnitude < stoppingVelocity)
                {
                    // Tell the GameManager to spawn next ball
                    GameManager.Instance.NextBall();
                    // Destroy self
                    Destroy(gameObject);
                }
                #endregion
            }
            else
            {
                #region Detect Mouse Click
                // If the mouse is pressed
                if (isPressed)
                {
                    // Get the current mouse position to the world
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ScreenToWorldPoint means to convert the camera view (2D) to game engine dimensions (3D), even if the game world is 2D
                                                                                            // Get distance between mouse to anchor
                    float distance = Vector3.Distance(mousePos, anchor.position);
                    // Is the distance of the mouse from the anchor greater than max drag distance?
                    if (distance > maxDragDistance)
                    {
                        // Get direction from anchor to mouse
                        Vector2 direction = (mousePos - anchor.position).normalized;
                        // Restrict the position of the player to the max distance
                        ball.position = anchor.position + direction * maxDragDistance;
                    }
                    else // Otherwise
                    {
                        // Set the ball's position to wherever the mouse is
                        ball.position = mousePos;
                    }
                }
                #endregion
            }

        }

        // When the mouse is down, this function is called
        private void OnMouseDown()
        {
            isPressed = true;
            ball.isKinematic = true;
        }
        // When the mouse is released, this function is called
        private void OnMouseUp()
        {
            isPressed = false;
            ball.isKinematic = false;

            // Run the coroutine (IEnumerator Release())
            StartCoroutine(Release());
        }

        // Run coroutine to release the ball
        IEnumerator Release()
        {
            // Wait a few seconds (using release time)
            yield return new WaitForSeconds(releaseTime);

            // Disable the spring joint
            spring.enabled = false;

            // Disable script (Ball.cs attached to GameObject)
            // 'this refers to this current script (Ball.cs)
            isReleased = true;
        }
    }
}
