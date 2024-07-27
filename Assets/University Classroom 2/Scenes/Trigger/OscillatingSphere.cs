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
        private float delay = 5;
        private float timer;


        void Start()
        {
            // Calculate the angular speeds
            speed = (2 * Mathf.PI) / 25.0f; // Full revolution in 25 seconds

        }
        void Update()
        {
            timer += Time.deltaTime;
            // Debug.Log(timer);
            if (timer > delay)
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
}
