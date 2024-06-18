using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borderTrigger : MonoBehaviour
{
    public static bool goingNorth;
    public static bool goingSouth;
    public static bool goingWest;
    public static bool goingEast; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // Debug.Log("detected collision");

            if (goingNorth || goingSouth || goingWest || goingEast)
            {
                //allow the current movement to finish 
                //stop detecting collisions
             //   gameObject.GetComponent<Collider>().isTrigger = false; 
            }

            else if (gameObject.tag == "north")
            {
                goingNorth = true;
                Debug.Log("going north");
            }
            if (gameObject.tag == "south")
            {
                Debug.Log("going south");
                goingSouth = true; 
            }
            if (gameObject.tag == "west")
            {
                Debug.Log("going west");
                goingWest = true; 
            }
            if (gameObject.tag == "east")
            {
                Debug.Log("going east");
                goingEast = true; 
            }
        }
    }
}
