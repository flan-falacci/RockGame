using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashandStep : MonoBehaviour
{
    public static bool touchingWater;
    public bool touchingWaterDebug; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (touchingWater == true)
        {
            touchingWaterDebug = true; 
        }else if (touchingWater == false)
        {
            touchingWaterDebug = false; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "splash")
        {
            touchingWater = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "splash")
        {
            touchingWater = false; 
        }
    }
}
