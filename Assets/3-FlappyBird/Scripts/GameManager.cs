using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using Unity's UI resources
using UnityEngine.UI;

namespace FlappyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance;
        // When the game starts (before Start())
        private void Awake()
        {
            // Set instance to current gameobject
            Instance = this;
        }
        // If the object is destroyed
        private void OnDestroy()
        {
            // Remove instance reference
            Instance = null;
        }
        #endregion

        public bool gameOver = false;
        public float scrollSpeed = -1.5f;
        public int score = 0;
        public Text scoreText;

        // Adding score to total score
        public void AddScore(int scoreToAdd)
        {
            // Increase score with incoming score
            score += scoreToAdd;
            // Update UI
            scoreText.text = score.ToString();
        }
    }
}
