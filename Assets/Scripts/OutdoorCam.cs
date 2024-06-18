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
    Quaternion northQuat;

    Vector3 westPos;
    Vector3 westEuler;
    Quaternion westQuat; 

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
        //EAST
        eastPos = new Vector3(basePos.x + 7.36f, basePos.y, basePos.z + 6.5f);
        eastEuler = new Vector3(baseEuler.x, baseEuler.y - 90, baseEuler.z);
        eastQuat = Quaternion.Euler(eastEuler);
        //NORTH
        northPos = new Vector3(basePos.x, basePos.y, basePos.z + 14.3f);
        northEuler = new Vector3(baseEuler.x, baseEuler.y +180, baseEuler.z);
        northQuat = Quaternion.Euler(northEuler);
        //WEST
        westPos = new Vector3(basePos.x - 7.3f, basePos.y, basePos.z + 6.5f);
        westEuler = new Vector3(baseEuler.x, baseEuler.y + 90, baseEuler.z);
        westQuat = Quaternion.Euler(westEuler);
        
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

            if (myCamTrans.position == eastPos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atBase = false;
                atEast = true;
                LerpingRight = false;
            }
        }
        //rotating left from base
        if (atBase && LerpingLeft)
        { 
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, westPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), westQuat, timer);

            if (myCamTrans.position == westPos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atBase = false;
                atWest = true;
                LerpingLeft = false;
            }
        }
        if (atEast && LerpingRight)
        {
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, northPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), northQuat, timer);

            if (myCamTrans.position == northPos)
            {
                timer = 0;
                atEast = false;
                atNorth = true;
                LerpingRight = false;
            }
        }
        else if (atEast && LerpingLeft)
        {
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, basePos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), baseQuat, timer);

            if (myCamTrans.position == basePos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atEast = false;
                atBase = true;
                LerpingLeft = false;
            }
        }
        if (atNorth && LerpingRight)
        {
            //North to West
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, westPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), westQuat, timer);

            if (myCamTrans.position == westPos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atNorth = false;
                atWest = true;
                LerpingRight = false;
            }
        }
        else if (atNorth && LerpingLeft)
        {
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, eastPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), eastQuat, timer);

            if (myCamTrans.position == eastPos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atNorth = false;
                atEast = true;
                LerpingLeft = false;
            }
        }
        if (atWest && LerpingRight)
        {
            //west to Base
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, basePos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), baseQuat, timer);

            if (myCamTrans.position == basePos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atWest = false;
                atBase = true;
                LerpingRight = false;
            }
        }
        else if (atWest && LerpingLeft)
        {
            //west to north 
            timer += Time.deltaTime * lerpSpeed;
            myCamTrans.position = Vector3.Lerp(myCamTrans.position, northPos, timer);
            myCamTrans.rotation = Quaternion.Slerp(Quaternion.Euler(myCamTrans.eulerAngles), northQuat, timer);

            if (myCamTrans.position == northPos)
            {
                Debug.Log("finished lerp");
                timer = 0;
                atWest = false;
                atNorth = true;
                LerpingLeft = false;
            }
        }
    }
   
  }
    

