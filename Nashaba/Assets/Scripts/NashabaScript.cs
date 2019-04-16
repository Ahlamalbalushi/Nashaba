using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;

public class NashabaScript : MonoBehaviour
{
    public GameObject Shooter;
    public Transform FirstPersonCamera;

    /// position of Shooter
    public Transform InitPosition;

    public Camera myCamera;


    //public Vector3 ShooterPos;
    Vector3 touchPosition, whereToMove;
    bool isMoving = false;
    float PreviosDistanceToTochPos, CurrentDistanceToTochPos;

    Rigidbody shooterRB;
    GameObject CurrentShooter;
  
    public float xMin, xMax, zMin, zMax, yMin, yMax;
    Vector3 OrigihnalPos;
    Vector3 currentTouch;

    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {
        shooterRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTouch = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;

            if (currentTouch.y > yMax - 50)
            {
                CurrentShooter.transform.position = OrigihnalPos;
            }
        }

        

        if (isMoving)
        {
            Vector3 clampedTouch = new Vector3(currentTouch.x, Mathf.Min(currentTouch.y,yMax), 2 - (touchPosition.y - Mathf.Min(currentTouch.y, yMax)) / Screen.height * 3);
            float distance = 0.5f;
            CurrentShooter.transform.position = Vector3.MoveTowards(InitPosition.position, myCamera.ScreenToWorldPoint(clampedTouch), distance);
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
    }


    public void ShooterCLicked()
    {
        isMoving = true;
        touchPosition = Input.mousePosition;
    }


}
