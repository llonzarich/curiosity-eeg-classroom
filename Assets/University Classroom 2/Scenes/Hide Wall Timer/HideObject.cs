using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        StartCoroutine(HandleVisibility());
    }

    private IEnumerator HandleVisibility()
    {
        // Wait for 60 seconds
        yield return new WaitForSeconds(5f);

        // Make the cube disappear
        cubeRenderer.enabled = false;

        // Wait for 15 seconds
        yield return new WaitForSeconds(28f);

        // Make the cube reappear
        cubeRenderer.enabled = true;
    }
}
