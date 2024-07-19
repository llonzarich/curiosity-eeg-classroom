using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTimer : MonoBehaviour
{
    private Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(HandleVisibility());
    }

    private IEnumerator HandleVisibility()
    {
        // Wait for x seconds
        yield return new WaitForSeconds(5f);

        // Make the cube disappear
        objectRenderer.enabled = false;

        // Wait for x seconds
        yield return new WaitForSeconds(5f);

        // Make the cube reappear
        objectRenderer.enabled = true;
    }
}
