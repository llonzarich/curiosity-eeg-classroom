using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSL4Unity.Samples.SimplePhysicsEvent
{
    public class OscillatingSphere : MonoBehaviour
    {
        public float moveDuration = 2.0f;
        public Vector3[] targets = new Vector3[7];

        private void Start()
        {
            // Define the 7 points in a square pattern
            targets[0] = new Vector3(1, 0, 1);
            targets[1] = new Vector3(-1, 0, 1);
            targets[2] = new Vector3(-1, 0, 0);
            targets[3] = new Vector3(-1, 0, -1);
            targets[4] = new Vector3(0, 0, -1);
            targets[5] = new Vector3(1, 0, -1);
            targets[6] = new Vector3(1, 0, 0);

            StartCoroutine(MoveToAllTargets());
        }

        IEnumerator MoveToAllTargets()
        {
            while (true) // Loop indefinitely
            {
                foreach (Vector3 target in targets)
                {
                    yield return StartCoroutine(MoveSphere(target));
                }
            }
        }

        IEnumerator MoveSphere(Vector3 targetPosition)
        {
            Vector3 startPosition = transform.position;
            float timeElapsed = 0.0f;

            while (timeElapsed < moveDuration)
            {
                timeElapsed += Time.deltaTime;
                float t = timeElapsed / moveDuration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}

