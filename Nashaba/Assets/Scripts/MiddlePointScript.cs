using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePointScript : MonoBehaviour
{

   
    Vector3 touchPosition;
    Vector3 originalPosition;
    bool isMoved;
    bool isdisableNashaba = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        isMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        touchPosition = Input.mousePosition;

        if (Input.GetMouseButton(0) && !isdisableNashaba)
        {
            transform.position = touchPosition;
            isMoved = true;

            if (touchPosition.y < 19)
            {
                isdisableNashaba = true;

            }
        }

        if (Input.GetMouseButtonUp(0) && (isMoved = true))
        {
            transform.position = originalPosition;
            isMoved = false;
            isdisableNashaba = false;

        }
    }
    }
