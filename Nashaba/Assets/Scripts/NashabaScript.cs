﻿using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;


#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif
public class NashabaScript : MonoBehaviour
{
    public GameObject Shooter;
    public Transform FirstPersonCamera;
    /// position of Shooter
    public Transform InitPosition;
    public Camera myCamera;
    Vector3 touchPosition;
    bool isMoving = false;
    Rigidbody shooterRB;
    GameObject CurrentShooter;
    public float yMax;
    public float yMin;
    Vector3 OrigihnalPos;
    Vector3 currentTouch;
    //float Force = 50;
    float power;
    public float PowerFactor;
    Vector3 ShootingAngle;
    float distance;
    bool isShooterCreated = false;


    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {
        //shooterRB = CurrentShooter.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Touch touch;



        currentTouch = Input.mousePosition;
        if (Input.GetMouseButtonUp(0) && isShooterCreated)
        {

            isMoving = false;
         
            ShootingAngle = (InitPosition.localPosition - CurrentShooter.transform.localPosition).normalized;


            //print("initalPosition" + InitPosition.localPosition);
           // print("cuurent shooter transform " + CurrentShooter.transform.localPosition);

            //print("Shooting angle" + ShootingAngle);

            power = (InitPosition.localPosition - CurrentShooter.transform.localPosition).magnitude;
            
            //DestroyShooter();
            //Invoke("DestroyShooter", 5);
            //shooterRB.AddForce(transform.forward * Power);
            shooterRB.useGravity = true;

            CurrentShooter.transform.parent = null;

            shooterRB.AddForce(ShootingAngle * power * PowerFactor);

            CurrentShooter.GetComponent<ShooterScript>().shot();
                

            if (currentTouch.y > yMax - 50)
            {
                CurrentShooter.transform.position = OrigihnalPos;
            }

            isShooterCreated = false;

            Invoke("InstShooter", 2);

        }


        if (isMoving && isShooterCreated)
        {
            Vector3 clampedTouch = new Vector3(currentTouch.x, Mathf.Clamp(currentTouch.y, yMin, yMax), InitPosition.localPosition.z - (touchPosition.y - Mathf.Clamp(currentTouch.y, yMin, yMax)) / Screen.height);
            distance = 0.5f;
            CurrentShooter.transform.position = Vector3.MoveTowards(InitPosition.position, myCamera.ScreenToWorldPoint(clampedTouch), distance);
            //Force replaced by power 
            //float Shooterdistance = (touchPosition.y - clampedTouch.y);
            //Force = Shooterdistance * 20;
        }
    }



    public void setShooter()
    {
        gameObject.SetActive(true);
        InstShooter();
    }

    public void InstShooter()
    {
        CurrentShooter = Instantiate(Shooter, InitPosition.position, transform.rotation, transform);
        OrigihnalPos = CurrentShooter.transform.position;
        CurrentShooter.GetComponent<ShooterScript>().clicked = ShooterCLicked;

        shooterRB = CurrentShooter.GetComponent<Rigidbody>();
        isShooterCreated = true;
    }


    public void ShooterCLicked()
    {
        isMoving = true;
        touchPosition = Input.mousePosition;


    }
    public void DestroyShooter()
    {
            //Destroy(CurrentShooter);
        
    }
}
