using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
   public bool isWalking;
   public bool isRunning;
    bool pickingUp;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    Animator kidController; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        kidController = gameObject.GetComponentInChildren<Animator>();

        //basic movement
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * Time.deltaTime * walkSpeed;
            isWalking = true; 

            if (isRunning)
            {
                transform.position += -transform.right * Time.deltaTime * runSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * walkSpeed;
            isWalking = true;

            if (isRunning)
            {
                transform.position += -transform.forward * Time.deltaTime * runSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * walkSpeed;
            isWalking = true;

            if (isRunning)
            {
                transform.position += transform.forward * Time.deltaTime * runSpeed;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * walkSpeed;
            isWalking = true;
           

            if (isRunning)
            {
                transform.position += transform.right * Time.deltaTime * runSpeed;
            }
        }
        else
        {
            isWalking = false;
        }

  
        //check if running 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true; 
        }
        else
        {
            isRunning = false; 
        }
        /*
        //pickup (debug)
        if (Input.GetKey(KeyCode.Space))
        {
            pickingUp = true; 
        }
        */

        //set animation bools 
        if (isWalking)
        {
            kidController.SetBool("isWalking", true);
        }
        else if (!isWalking)
        {
            kidController.SetBool("isWalking", false);
        }
        if (isRunning)
        {
            kidController.SetBool("isRunning", true);
        }else if (!isRunning)
        {
            kidController.SetBool("isRunning", false);
        }
        if (pickingUp)
        {
            kidController.SetBool("pickingUp", true);
        }

    }
}
