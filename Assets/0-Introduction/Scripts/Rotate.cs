// Namespaces
using System.Collections; // .NET (a library which contains pre-written code that you can use)
using System.Collections.Generic; // .NET (a library which contains pre-written code that you can use)
using UnityEngine; // Code from Unity

// Code clean-up: CTRL + K + D

// Save all scripts: Ctrl + Shift + S

// Class Object
public class Rotate : MonoBehaviour
{
    // Variables

    public float rotationSpeed = 5;
    // Use this for initialization
    void Start()
    {
        // Any code you write here will run at the start of the game
       
        print("Run Forest!");
    }

    // Update is called once per frame
    void Update()
    {
        // If W is pressed
        if (Input.GetKey(KeyCode.W))
        {
            // Do this
            transform /* the transform of the object this script is attached to */ .Rotate(new Vector3(rotationSpeed, 0, 0)); 
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(-rotationSpeed, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        }
    }
}
