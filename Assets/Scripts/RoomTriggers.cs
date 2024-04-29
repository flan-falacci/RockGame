using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTriggers : MonoBehaviour
{
    [SerializeField] Vector3 myPos;
    [SerializeField] Vector3 myRot;
    [SerializeField] float cameralerpRate;

    [SerializeField] GameObject myButton; 

     Vector3 defaultPos;
     Vector3 defaultRot; 

    float t; 

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = new Vector3(-1.5f,4.74f,-5.93f);
        defaultRot = new Vector3(36.12f, 0,0);

        Camera.main.transform.position = defaultPos;
        Camera.main.transform.eulerAngles = defaultRot;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * cameralerpRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, myPos, t);
            Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, myRot, t);

            myButton.SetActive(true);
        }
   
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, defaultPos, t);
            Camera.main.transform.eulerAngles = Vector3.Lerp(Camera.main.transform.eulerAngles, defaultRot, t);

            myButton.SetActive(false);
        }
    }
}
