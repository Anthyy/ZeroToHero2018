using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorSwitch
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // 'Transform' is used to reference something outside of this script, i.e. something other than the object that this script will be attached to (in this case, the player)

        // Update is called once per frame
        void Update()
        {
            Vector3 camPos = transform.position;
            Vector3 targetPos = target.position;
            // If target position's y is greater than CamPos' y
            if(targetPos.y > camPos.y)
            {
                // Update camera's position
                //transform.Translate(camPos.x, targetPos.y, camPos.z);
                transform.position = new Vector3(camPos.x, targetPos.y, camPos.z);
            }
        }
    }
}
