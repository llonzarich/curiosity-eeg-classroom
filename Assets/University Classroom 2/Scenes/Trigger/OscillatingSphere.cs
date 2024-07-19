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
        private float slowSpeed;
        private float fastSpeed;
        private float elapsedTime = 0.0f;


        void Start()
        {
            // Calculate the angular speeds
            fastSpeed = (2 * Mathf.PI) / 14.0f; // Full revolution in 14 seconds
            slowSpeed = fastSpeed * (14.0f / 28.0f); // Full revolution in 28 seconds
            angularSpeed = fastSpeed; // Start with fast speed
            
        }
        void Update()
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 10.0f && elapsedTime < 14.0f)
            {
                // Slow down the speed
                angularSpeed = slowSpeed;
            }
            else
            {
                // Use the normal speed
                angularSpeed = fastSpeed;
            }
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
