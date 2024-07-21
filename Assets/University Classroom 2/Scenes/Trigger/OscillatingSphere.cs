using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class OscillatingSphere : MonoBehaviour
    {
        public float radius = 1.0f; // Radius of the circle (increase this for a larger circle)
        private float angle = 0.0f; // Current angle
        private float speed; // radians per second


        void Start()
        {
            // Calculate the angular speeds
            speed = (2 * Mathf.PI) / 14.0f; // Full revolution in 14 seconds

        }
        void Update()
        {
            // Calculate position on circle
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            // Update object position
            transform.position = new Vector3(x, 0.0f, z);
            // Increment angle based on angular speed
            angle += speed * Time.deltaTime;
        }
    }
}
