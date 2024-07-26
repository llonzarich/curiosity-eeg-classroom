using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRatingReappear : MonoBehaviour
{
    [SerializeField] 
    public GameObject cube1, cube2, cube3, cube4, cube5, cube6;
   
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube_1s")
        {
            cube1.gameObject.SetActive(false); 
            cube2.gameObject.SetActive(false); 
            cube3.gameObject.SetActive(false); 
            cube4.gameObject.SetActive(false); 
            cube5.gameObject.SetActive(false); 
            cube6.gameObject.SetActive(false); 
        } 
        else if(other.gameObject.name == "Cube_4s")
        {
            cube1.gameObject.SetActive(false); 
            cube2.gameObject.SetActive(false); 
            cube3.gameObject.SetActive(false); 
            cube4.gameObject.SetActive(false); 
            cube5.gameObject.SetActive(false); 
            cube6.gameObject.SetActive(false); 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Cube_1s")
        {
            cube1.gameObject.SetActive(true);
            cube2.gameObject.SetActive(true);
            cube3.gameObject.SetActive(true);
            cube4.gameObject.SetActive(true);
            cube5.gameObject.SetActive(true);
            cube6.gameObject.SetActive(true);
        }
        else if(other.gameObject.name == "Cube_4s")
        {
            cube1.gameObject.SetActive(true); 
            cube1.gameObject.SetActive(true);
            cube2.gameObject.SetActive(true);
            cube3.gameObject.SetActive(true);
            cube4.gameObject.SetActive(true);
            cube5.gameObject.SetActive(true);
            cube6.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
