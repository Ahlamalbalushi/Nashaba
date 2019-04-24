using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePointScript : MonoBehaviour
{

   
    Vector3 touchPosition;
    Vector3 originalPosition;
    bool isMoved;
    bool isdisableNashaba = false;
    public float yMax;
    public float yMin;
    public NashabaScript nashaba;
    internal bool isShooterMoved;


    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        isMoved = false;
        yMax = nashaba.yMax;
        yMin = nashaba.yMin;
        
    }

    // Update is called once per frame
    void Update()
    {
         isShooterMoved = nashaba.isMoving;
        touchPosition = Input.mousePosition;
        touchPosition = new Vector3(touchPosition.x, Mathf.Clamp(touchPosition.y, yMin, yMax), touchPosition.z - (touchPosition.y - Mathf.Clamp(touchPosition.y, yMin, yMax)) / Screen.height);

        if (Input.GetMouseButton(0) &&  isShooterMoved)
        {
            transform.position = touchPosition;
            isMoved = true;

            //if (touchPosition.y < 19)
            //{
            //    isdisableNashaba = true;

            //}
        }

        if (Input.GetMouseButtonUp(0) && (isMoved = true))
        {
            transform.position = originalPosition;
            isMoved = false;
            isdisableNashaba = false;

        }
    }
    }
