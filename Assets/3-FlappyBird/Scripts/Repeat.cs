using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Repeat : MonoBehaviour
    {

        private BoxCollider2D box;

        [SerializeField]
        private float width;

        // Use this for initialization
        void Start()
        {
            // Get boxcollider component
            box = GetComponent<BoxCollider2D>();
            // Store size of collider along horizontal axis
            width = box.size.x;
        }

        // Update is called once per frame
        void Update()
        {
            // Get position from transform
            Vector2 pos = transform.position;
            // Is the position outside the -width?
            if(pos.x < -width)
            {
                // This is when we repeat the object to other side
                OffsetPosition();
            }
        }

        void OffsetPosition()
        {
            // Get offset position for the ground (outside screen)
            transform.position += /* position = position + offset */ new Vector3(width * 2, 0); 
        }
    } 
}
