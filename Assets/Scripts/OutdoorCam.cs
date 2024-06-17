using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorCam : MonoBehaviour
{
    //POS +ROTS
    Vector3 basePos;
    Vector3 baseEuler;
    Quaternion baseQuat;

    Vector3 eastPos;
    Vector3 eastEuler;
    Quaternion eastQuat; 

    Vector3 northPos;
    Vector3 northEuler;

    Vector3 westPos;
    Vector3 westEuler;

    //CAMERA
    Camera myCam;
    Transform myCamTrans; 

    //MOVEMENT 
    float t;
    public float lerpSpeed;
    float timer;

    //BOOLS
    bool LerpingRight;
    bool LerpingLeft;

    bool atBase;
    bool atEast;
    bool atNorth;
    bool atWest; 

    // Start is called before the first frame update
    void Start()
    {
       //SET CAMERA TO MAIN
        myCam = Camera.main;
        myCamTrans = myCam.gameObject.transform;

        //SET POS + ROTS FOR EACH ORIENTATION 
        basePos = Camera.main.gameObject.transform.position;
        baseEuler = Camera.main.gameObject.transform.eulerAngles;
        baseQuat = Quaternion.Euler(baseEuler);

        eastPos = new Vector3(basePos.x + 8.36f, basePos.y, basePos.z + 6.5f);
        eastEuler = new Vector3(baseEuler.x, baseEuler.y - 90, baseEuler.z);
        eastQuat = Quaternion.Euler(eastEuler);

        //set bools 
        atBase = true;
        atEast = false;
        atNorth = false;
        atWest = false;

        timer = 0; 
    }
    //CONSTANT
    //x rotation is always 36.3
    //z rotation is always 0
    //y position is always 5.25

    //BASE (when looking at square 0,0 facing north) 
    //z position STARTS at -7
    //x potisin STARTS at 0

    //RIGHT MOVE
    //-90 Y rotation

    //xposition is now 8.36 (about half the square length) 
    //z position is now -0.177 (minor adjustment?)

    void Update()
    {
        if (LerpingLeft || LerpingRight)
        {
            //allow current lerp to finish
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                LerpingRight = true;
                LerpingLeft = false; 
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                LerpingLeft = true;
                LerpingRight = false; 
            }
        }

        //rotating right from base
        if (atBase && LerpingRight)
        {
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, eastPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), eastQuat, timer);

            if (myCamTrans.rotation == eastQuat)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atBase = false;
                atEast = true;
                LerpingRight = false;
            }
        }
    }
   
  }
    

