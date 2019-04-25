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
    internal float yMax;
    internal float yMin;
    public NashabaScript nashaba;
    public float ShakingTime = 0.1f; // duration of shake 

    public float shakeRange = 50f; // shake range 
                                   //keep it mind that max it can go is half in either direction
                                   // Start is called before the first frame update
   internal bool isShooterMoved;

 
       
    void Start()
    {
        rect = GetComponent<RectTransform>();
        isMoved = false;
        originalTransform = transform.eulerAngles;
        rectSize = rect.sizeDelta;
        yMax = nashaba.yMax;
        yMin = nashaba.yMin;
       
       // print("clamp" + yMin);

    }

    // Update is called once per frame
    void Update()
    {
     
        isShooterMoved = nashaba.isMoving;
        touchPosition = Input.mousePosition;
        touchPosition = new Vector3(touchPosition.x, Mathf.Clamp(touchPosition.y, yMin, yMax), touchPosition.z - (touchPosition.y - Mathf.Clamp(touchPosition.y, yMin, yMax)) / Screen.height);
       

        // if (Input.GetMouseButton(0) && !isdisableNashaba)
        if (Input.GetMouseButton(0) && isShooterMoved)
         {
     
            Length = (touchPosition - gameObject.transform.position) ;
            LasticLength = Length.magnitude;
        
            lasticangle = Mathf.Atan2(Length.y,Length.x)* Mathf.Rad2Deg;
       
            // apply the angle in rotaion of z 
     
            transform.eulerAngles = new Vector3(0, 0, lasticangle);
            rect.sizeDelta = new Vector2(LasticLength - 50, Mathf.Clamp(rectSize.y - (LasticLength - rectSize.x) * 0.1f, 10, rectSize.y)); // restrict length of lastic
            isMoved = true;

           // print("toch" + Input.mousePosition);


        }
        if (Input.GetMouseButtonUp(0) && (isMoved = true))
        {

           
            transform.eulerAngles = originalTransform;
            rect.sizeDelta = rectSize;
            isMoved = false;
            if (isShooterMoved)
            {

           
            StartCoroutine(NashabaShake());
            }
            // isdisableNashaba = false;



        }


    }

    private IEnumerator NashabaShake()
    {
       // print("shaking starts");
        float elapsed = 0.0f;
        Vector3 originalRotation = transform.localEulerAngles;

        while (elapsed < ShakingTime)
        {

            elapsed += Time.deltaTime;
           // float z = Random.value
            float z = Random.value * shakeRange - (shakeRange / 2);
            transform.localEulerAngles = new Vector3(originalRotation.x, originalRotation.y, originalRotation.z + z);
            yield return null;
        }

        transform.localEulerAngles = originalRotation;
    }



}

