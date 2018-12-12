using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Extras.Menu
{
    public class MenuHandler : MonoBehaviour
    {
        // In order to attach a function to a UI element, it needs to be public
        public void Play(int sceneId) // The scene ID is a number
        {
            // Loads scene by scene index number
            SceneManager.LoadScene(sceneId);
        }

        public void Exit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying /* This is checking for if the scene is in play mode */ = false; // So then when this function is called, '= false' just makes it so it exits play mode
            #endif 
            // Exits or quits .exe Applications 
            Application.Quit(); // In a fully compiled game, it will jump straight to this line of code and quit the game
        }
    }
}
