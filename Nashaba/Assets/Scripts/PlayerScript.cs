using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;

public class PlayerScript : MonoBehaviour
{
    DetectedPlaneGenerator DetectedPlaneGeneratorscript;
    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(DetectedPlaneGeneratorscript.isCreatedOnce == true)
       // {
            Instantiate(gameObject,new Vector3(0, 0, 0), transform.rotation);
          
        //}
        
    }

    
}
