using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLasticScript : MonoBehaviour
{


    Vector3 Length;
    Vector3 touchPosition;
    float LasticLength;
    float lasticangle;
    RectTransform rect;
    Vector3 originalTransform;
    Vector3 rectSize;
    bool isMoved = false;
    bool isdisableNashaba= false;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        originalTransform = transform.eulerAngles;
        rectSize = rect.sizeDelta;
        isMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        touchPosition = Input.mousePosition;
   

        if (Input.GetMouseButton(0) && !isdisableNashaba)
        {
         // print("Touch Position" + touchPosition);
            Length = (touchPosition - gameObject.transform.position);
            LasticLength = Length.magnitude;
       //   print("length" + LasticLength);
            lasticangle = Mathf.Atan2(Length.y, Length.x) * Mathf.Rad2Deg;
         // print(lasticangle);
            isMoved = true;
            // apply the angle in rotaion of z 


            transform.eulerAngles = new Vector3(0, 0, lasticangle + 180);
      

            //Vector2 newsize = rect.sizeDelta;
            // newsize.y = LasticLength;
            // rect.sizeDelta = newsize;

            rect.sizeDelta = new Vector2(LasticLength, rect.sizeDelta.y - .03f);
            // print("y" + touchPosition.y);
            print("lenght" + lasticangle);
           

            if (touchPosition.y < 19)
            {
                isdisableNashaba = true;

            }
            

            if (LasticLength < -10)
            {
                LasticLength = -10;
            }
        }

        if (Input.GetMouseButtonUp(0) && (isMoved = true))
        {
            transform.eulerAngles = originalTransform;
            rect.sizeDelta = rectSize;
            isMoved = false;
            isdisableNashaba = false;


        }

    }
}
