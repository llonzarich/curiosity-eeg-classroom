using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class OscillatingSphere : MonoBehaviour
    {
        public float radius = 1.0f; // Radius of the circle (increase this for a larger circle)
        private float angle = 0.0f; // Current angle
        private float angularSpeed; // Angular speed (radians per second)
        void Start()
        {
            // Calculate the angular speed for a 14-second revolution
            angularSpeed = (2 * Mathf.PI) / 14.0f;
        }
        void Update()
        {
            // Calculate position on circle
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            // Update object position
            transform.position = new Vector3(x, 0.0f, z);
            // Increment angle based on angular speed
            angle += angularSpeed * Time.deltaTime;
        }
    }
}

