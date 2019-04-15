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
    


    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {
        //OriginalPos = ShooterPos;
        shooterRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
   void Update()
    {
        //if (!isMoving)
        //CurrentDistanceToTochPos = (touchPosition - transform.position).magnitude;

        if (Input.GetMouseButtonDown(0))
        {


            PreviosDistanceToTochPos = 0;
            CurrentDistanceToTochPos = 0;

            //touchPosition.z = 0;
            //whereToMove = (touchPosition - transform.position).normalized;
            //shooterRB.velocity = new Vector2(whereToMove.x * 5, whereToMove.y * 5);



        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (CurrentDistanceToTochPos > PreviosDistanceToTochPos)
        {
            isMoving = false;
            shooterRB.velocity = Vector2.zero;
        }

        if (isMoving)
        {
            Vector3 currentTouch = Input.mousePosition;

            CurrentShooter.transform.position = myCamera.ScreenToWorldPoint(new Vector3(currentTouch.x, currentTouch.y,2  - (touchPosition.y - currentTouch.y) / Screen.height * 3));

           
            //PreviosDistanceToTochPos = (touchPosition - transform.position).magnitude;
        }

    }


    

   public void setShooter()
    {
        gameObject.SetActive(true);
        InstShooter();
    }

    public void InstShooter()
    {
        CurrentShooter = Instantiate(Shooter, InitPosition.position, transform.rotation,transform);

        CurrentShooter.GetComponent<ShooterScript>().clicked = ShooterCLicked;
    }


    public void ShooterCLicked()
    {
        isMoving = true;
        touchPosition = Input.mousePosition;
    }

    
}
