using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class ColumnSpawner : MonoBehaviour
    {
        public GameObject columnPrefab; // The column prefab we want to spawn
        public int columnPoolSize = 5; // How many columns to keep on standby
        [Tooltip("How quickly each column spawns (in seconds)")]       
        public float spawnRate = 3f; // How quickly each column spawns
        public float minY = -1f; // Minimum y value for the column pos
        public float maxY = 3.5f; // Maximum y value for the column pos
        public Transform standby; // Holding position for the unused columns offscreen
        public float spawnXPos = 10f; // Spawning      

        private GameObject[] columns; // Collection of spawned columns (thanks to the pool size)
        private int currentColumn = 0; // Index of the current column selected for "respawning"
        private float spawnTimer = 0f; // Elapsed time from spawning a column

        // Use this for initialization
        void Start()
        {
            // Create a pool using column size
            columns = new GameObject[columnPoolSize];
            // Loop through the columns
            for (int i = 0; i < columnPoolSize; i++)
            {
                // Spawn the individual columns
                columns[i] = Instantiate(columnPrefab, standby.position, standby.rotation);
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Count up the timer - count up in seconds
            spawnTimer += Time.deltaTime;
            // If game is NOT over AND spawnTimer >= spawnRate
            if (GameManager.Instance.gameOver == false && spawnTimer >= spawnRate)
            {
                // Spawn the next column
                SpawnColumn();
                // Reset timer
                spawnTimer = 0f;
            }
        }

        // Reset position of column to outside of map (coming into the game)
        void SpawnColumn()
        {
            // Minimum y value for the column pos
            float spawnYPos = Random.Range(minY, maxY);
            // Get current column from array
            GameObject column = columns[currentColumn];
            // Set position of the current column
            column.transform.position = new Vector2(spawnXPos, spawnYPos);
            // Increment the currentColumn (for the next time we run this function)
            currentColumn++;
            // If currentColumn exceeds columns array
            if(currentColumn >= columns.Length) // or >= columnPoolSize. It's just that .Length is a more hard setting
            {
                // Reset back to zero
                currentColumn = 0;
            }

        }
    } 
}
