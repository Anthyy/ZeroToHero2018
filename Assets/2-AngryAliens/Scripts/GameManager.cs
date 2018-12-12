using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace AngryAliens // you can also do 'using AngryAliens, or whatever namespace'
{

    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance;

        // When the game starts (before Start())
        private void Awake()
        {
            // Set instance to current gameObject
            Instance = this;
        }

        // If the object is destroyed
        private void OnDestroy()
        {
            // Remove instance reference
            Instance = null;
        }
        #endregion

        public GameObject[] balls;
        public int currentBall;

        void Start()
        {
            // Enable the current ball at the start
            SelectBall(currentBall);
        }

        void SelectBall(int ballIndex)
        {
            // Loop through all balls
            //  Creating a variable     // Condition      // Incrementation
            for (int i = 0;           i < balls.Length;       i++) // A for loop will run a set of statements multiple times
            {
                GameObject ball = balls[i];
                // If ball is not null
                if (ball)
                {
                    if (i == ballIndex)
                    {
                        // Enable current ball
                        ball.SetActive(true);
                    }
                    else
                    {
                        // Disable
                        ball.SetActive(false);
                    }
                }                
            }       
        }

        // When the current ball has stopped moving
        public void NextBall()
        {
            // Increase the currentBall index
            currentBall++;
            // Check if current ball exceeds array length
            if(currentBall >= balls.Length)
            {
                // Game Over - reset scene
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
            else
            {
                // Select the current ball
                SelectBall(currentBall);
            }           
        }
    }
}

