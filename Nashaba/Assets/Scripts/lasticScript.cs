using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasticScript : MonoBehaviour
{
    
 
    Vector3 Length;
    Vector3 touchPosition;
    float LasticLength;
    float lasticangle;
    RectTransform rect;
    RectTransform originalRec;
    Vector3 originalTransform;
    Vector3 rectSize;
    bool isMoved;
   // bool isdisableNashaba = false;
    public float yMax;
    public float yMin;
    public NashabaScript nashaba;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        isMoved = false;
        originalTransform = transform.eulerAngles;
        rectSize = rect.sizeDelta;
        yMax = nashaba.yMax;
        yMin = nashaba.yMin;

    }

    // Update is called once per frame
    void Update()
    {
       
       
        touchPosition = Input.mousePosition;
        touchPosition = new Vector3(touchPosition.x, Mathf.Clamp(touchPosition.y, yMin, yMax), touchPosition.z - (touchPosition.y - Mathf.Clamp(touchPosition.y, yMin, yMax)) / Screen.height);


        // if (Input.GetMouseButton(0) && !isdisableNashaba)
        if (Input.GetMouseButton(0))
         {
     
            Length = (touchPosition - gameObject.transform.position);
            LasticLength = Length.magnitude;
        
            lasticangle = Mathf.Atan2(Length.y,Length.x)* Mathf.Rad2Deg;
       
            // apply the angle in rotaion of z 
     
            transform.eulerAngles = new Vector3(0, 0, lasticangle + 180);
            rect.sizeDelta = new Vector2(LasticLength, Mathf.Clamp(rectSize.y - (LasticLength - rectSize.x) * 0.2f, 10, rectSize.y)); // restrict length of lastic
            isMoved = true;
           

        }
        if (Input.GetMouseButtonUp(0) && (isMoved = true))
        {

           
            transform.eulerAngles = originalTransform;
            rect.sizeDelta = rectSize;
            isMoved = false;
           // isdisableNashaba = false;



        }


    }
}
