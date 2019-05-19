using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;
using GoogleARCore.Examples.CloudAnchors;
#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class threedNashaba : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Shooter;
    public Transform FirstPersonCamera;
    /// position of Shooter
    public Camera myCamera;
    Vector3 touchPosition;
    public bool isMoving = false;
    Rigidbody shooterRB;
    GameObject CurrentShooter;
    float yMax;
    float yMin;
    Vector3 OrigihnalPos;
    Vector3 currentTouch;
    //float Force = 50;
    public float power;
    public float PowerFactor;
    Vector3 ShootingAngle;
    //public float distance;
    bool isShooterCreated = false;
    public LineRenderer lineRenderer;

    public Transform Holder;

    public HolderScript HolderScript;

    Vector3 OriginalHolderPos;
    Vector3 originalHolderRotaion;
    public Vector3 Acceleration;

    public Vector3 PlayerPos;
    public LocalPlayerController LocalPlayerScript;
    //bool isCreated;

    // Start is called before the first frame update
    void Start()
    {

        power = 0;
        HolderScript.clicked = ShooterCLicked;
        setShooter();
        OriginalHolderPos = Holder.localPosition;
        //originalHolderRotaion = nashababody.rotation;
        //print("rotaion" + nashababody.transform.localPosition);

    }

    // Update is called once per frame
    void Update()
    {
        //isCreated = LocalPlayerScript.isObjectCreated;

        currentTouch = Input.mousePosition;
        //if (Input.GetMouseButtonUp(0) && isShooterCreated && isMoving)
            if (Input.GetMouseButtonUp(0) && isShooterCreated && isMoving) 

            {
            StartCoroutine(ReturnToObject1());
            CurrentShooter.transform.parent = null;
            isMoving = false;
            ShootingAngle = (OriginalHolderPos - Holder.transform.localPosition).normalized;
            power = (OriginalHolderPos - Holder.transform.localPosition).magnitude;
            shooterRB.isKinematic = false;
            shooterRB.useGravity = true;
            shooterRB.AddForce(transform.TransformVector(ShootingAngle) * power * PowerFactor);
            CurrentShooter.GetComponent<ShooterScript>().shot();
            //CurrentShooter.transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
            if (currentTouch.y > yMax - 50)
            {
                CurrentShooter.transform.position = OrigihnalPos;
            }

            isShooterCreated = false;
            Invoke("InstShooter", 2);
        }

       // if ((isMoving) && (isCreated))
           if (isMoving)
        {

            yMin = Screen.height * 0.1f;
            yMax = Screen.height * 0.5f;

            float yoffset =  currentTouch.y - touchPosition.y;

            Vector3 clampedTouch = new Vector3(currentTouch.x, Mathf.Min(currentTouch.y + yoffset, yMax), OriginalHolderPos.z - (touchPosition.y - Mathf.Clamp(currentTouch.y, yMin, yMax))* 2 / Screen.height);
            //distance = 0.1f;
            Holder.transform.position = myCamera.ScreenToWorldPoint(clampedTouch);
            lineRenderer.SetPosition(1, Holder.localPosition + Vector3.right * 0.04f);
            lineRenderer.SetPosition(2, Holder.localPosition - Vector3.right * 0.04f);


            // Vector3 rot = (OriginalHolderPos - Holder.transform.localPosition).normalized;
            // nashababody.transform.position = new Vector3(nashababody.transform.position.z, ( Holder.transform.localPosition.y), nashababody.transform.position.z) ;

            // if (currentTouch.x != 0)
            // {
            float XPosition = (currentTouch.x - Screen.width / 2);
            //print("XPosition" + XPosition);
            XPosition /= (Screen.width / 2);
            // print("xposition" + XPosition);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -(XPosition) * 15, transform.localEulerAngles.z);
            //nashababody.transform.eulerAngles = new Vector3(nashababody.transform.eulerAngles.x, (nashababody.transform.eulerAngles.y - currentTouch.x) * 0.05f, nashababody.transform.eulerAngles.z);
            //}
            // print("holder " + Holder.transform.localPosition);

            ShootingAngle = transform.TransformVector((OriginalHolderPos - Holder.transform.localPosition).normalized);
            Acceleration = (ShootingAngle * (OriginalHolderPos - Holder.transform.localPosition).magnitude * PowerFactor) / shooterRB.mass;
            PlayerPos = CurrentShooter.transform.position;
           
        }
    }



    public void setShooter()
    {
        gameObject.SetActive(true);
        InstShooter();
    }

    public void InstShooter()
    {
        if (isShooterCreated == false)
        {
            CurrentShooter = Instantiate(Shooter, Holder.position + Holder.forward * 0.12f, transform.rotation, Holder);
            OrigihnalPos = CurrentShooter.transform.position;
            CurrentShooter.GetComponent<ShooterScript>().OnDestroyed = OnShooterDestroyed;

            shooterRB = CurrentShooter.GetComponent<Rigidbody>();
            isShooterCreated = true;
        }
    }

    void OnShooterDestroyed()
    {
        setShooter();
    }

    public void ShooterCLicked()
    {
        if (isShooterCreated && !isMoving)
        {
            isMoving = true;
            touchPosition = Input.mousePosition;
        }

    }

 
    public void DestroyShooter()
    {
        //Destroy(CurrentShooter);

    }


    IEnumerator ReturnToObject1()
    {

        while (OriginalHolderPos != Holder.transform.position)
        {

            Holder.transform.localPosition = Vector3.MoveTowards(Holder.transform.localPosition, OriginalHolderPos, Time.deltaTime * shooterRB.velocity.magnitude);

            lineRenderer.SetPosition(1, Holder.localPosition + Vector3.right * 0.04f);
            lineRenderer.SetPosition(2, Holder.localPosition - Vector3.right * 0.04f);
            //lineRenderer.SetPosition(1, OriginalHolderPos);
            yield return null;
        }
    }


}
