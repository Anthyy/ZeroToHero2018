using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Introduction
{
    public class GameManager : MonoBehaviour
    {
        public void RestartGame()
        {
            // Get current scene
            Scene /*is the data type of the variable*/ currentScene /*this is */ = /*to the*/ SceneManager.GetActiveScene /*function because it returns a scene (the current scene that is running)*/();
            // Reload current scene
            SceneManager.LoadScene(currentScene.name); // We then load currentScene by name or buildIndex as we can load scenes through strings or ints 
        }
    }
}
