using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixationChange : MonoBehaviour
{

    [SerializeField]
    GameObject cross;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        cross.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {

        cross.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
