using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Snake
{
    public class Spawner : MonoBehaviour // Btw, this script is called 'Spawner' because you can use the logic here to spawn anything in any other kind of game.
    {
        [Tooltip("Thing to spawn")]
        public GameObject prefab;
        [Header("References")]
        public Transform borderTop;
        public Transform borderBottom;
        public Transform borderRight;
        public Transform borderLeft;

        // Use this for initialization
        void Start()
        {
            // Subscribe 'Spawn' to GameManager's onSpawn delegate
            GameManager.Instance.onSpawn += Spawn;
            // Hey! I just met you, and this is crazy. So here's my Function so call me maybe
        }

        // When object is destroyed
        private void OnDestroy()
        {
            if (GameManager.Instance)
            {
                // UnSubscribe Spawn from GameManager
                GameManager.Instance.onSpawn -= Spawn;
            }          
        }

        // Spawns a new instance of the prefab within borders
        public void Spawn()
        {
            // Get coordinates of borders
            float top = borderTop.position.y;
            float bottom = borderBottom.position.y;
            float right = borderRight.position.x;
            float left = borderLeft.position.x;

            // Generate a random x and y coordinate for the prefab
            // Type-Casting (converting a type, in this case a float to an int)
            int x = (int)Random.Range(left + .5f, right - .5f); 
            int y = (int)Random.Range(top - .5f, bottom + .5f);

            // Spawn object at generated position
            Instantiate(prefab, // Original object to instantiate
                        new Vector2(x, y), // Position to spawn at
                        Quaternion.identity, // Default rotation to spawn at (0 rotation). Quaternions are a way to handle orientation in 3D space. It was developed by William Rowan Hamilton in the 19th century. Thanks to him we have camera rotation and nice kill cams (e.g. in Sniper Elite)
                        transform); // Transform to parent new object to
        }
    } 
}
