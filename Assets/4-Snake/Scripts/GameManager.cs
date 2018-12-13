using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Snake
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
        #endregion

        public int score = 0;
        [Header("UI")]
        public Text scoreText;

        // Delegate // A delegate is like a function variable

        public delegate void SpawnCallback(); // Because it's calling back a function that was made before
        public SpawnCallback onSpawn; // <-- Subscribe to this! 


        public void Spawn()
        {
            // If there are subscribed functions to this
            if(onSpawn != null)
            {
                // Invoke (call) those functions
                onSpawn.Invoke();
            }
        }

        // Use this for initialization   

        public void AddScore(int scoreToAdd)
        {
            // Increase score
            score += scoreToAdd;
            // Update UI
            scoreText.text = "Score: "+ score.ToString();
        }

        public void RestartGame()
        {
            // Get active scene
            Scene currentScene = SceneManager.GetActiveScene();
            // Reload active scene
            SceneManager.LoadScene(currentScene.name);
        }
    } 
}
