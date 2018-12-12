using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;  

// Inserts function: Ctrl + Shift + M
public class Ball : MonoBehaviour
{

    public UnityEvent onDeath;
    private void OnTriggerEnter(Collider other)
    {
        // If other object is a 'KillBox'
        if (other.name == "KillBox") 
        {
            // Run the On Death event!
            onDeath.Invoke();
        }

    }

}
