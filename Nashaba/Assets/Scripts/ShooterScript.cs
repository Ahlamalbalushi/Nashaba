using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShooterScript : MonoBehaviour
{

    public Action clicked;
    //Vector3 touchPosition, whereToMove;
    //bool isMoving = false;
    //float PreviosDistanceToTochPos, CurrentDistanceToTochPos;

    //Rigidbody shooterRB;
    //Touch touch;
    // Start is called before the first frame update
    void Start()
    {
       // shooterRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isMoving)
        //    CurrentDistanceToTochPos = (touchPosition - transform.position).magnitude;

        //if (Input.GetMouseButtonDown(0))
        //{


        //        PreviosDistanceToTochPos = 0;
        //        CurrentDistanceToTochPos = 0;
        //        isMoving = true;
        //        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        //touchPosition.z = 0;
        //        //whereToMove = (touchPosition - transform.position).normalized;
        //        //shooterRB.velocity = new Vector2(whereToMove.x * 5, whereToMove.y * 5);

            

        //}

        //if (CurrentDistanceToTochPos > PreviosDistanceToTochPos)
        //{
        //    isMoving = false;
        //    shooterRB.velocity = Vector2.zero;
        //}

        //if (isMoving)
        //{

        //    //PreviosDistanceToTochPos = (touchPosition - transform.position).magnitude;
        //}

    }

    private void OnMouseDown()
    {
        clicked.Invoke();
    }
}
