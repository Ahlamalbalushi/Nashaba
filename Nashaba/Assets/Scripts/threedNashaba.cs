using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;
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
    public float distance;
    bool isShooterCreated = false;
    LineRenderer lineRenderer;

    public Transform Holder;
    public HolderScript HolderScript;

    Vector3 OriginalHolderPos;
    public Vector3 Acceleration;

    public Vector3 PlayerPos;
    // public DetectedPlaneGenerator PlaneGenerator;
    //public GameObject NashabaParts;

    /// <summary>
    /// //////////////////////
    /// </summary>
    //  public Vector3 Acceleration;

    //public Vector3 PlayerPos;


    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {
        //shooterRB = CurrentShooter.GetComponent<Rigidbody>();
        // NashabaParts.SetActive(false);
        power = 0;
        lineRenderer = GetComponent<LineRenderer>();

        HolderScript.clicked = ShooterCLicked;

        setShooter();

        OriginalHolderPos = Holder.localPosition;
       
    }

    // Update is called once per frame
    void Update()
    {

        //if (PlaneGenerator.isCreatedOnce == true)
        //{
        //    NashabaParts.SetActive(true);

        //}


        currentTouch = Input.mousePosition;
        if (Input.GetMouseButtonUp(0) && isShooterCreated && isMoving)
        // if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ReturnToObject1());
            CurrentShooter.transform.parent = null;
            //  Holder.transform.position = OriginalHolderPos;
            //  lineRenderer.SetPosition(1, OriginalHolderPos);
            //  lineRenderer.SetPosition(2, OriginalHolderPos);
            ////////////////////////////////////////////
            //  lineRenderer.SetPosition(1, Holder.position - Holder.right * 0.05f);
            //lineRenderer.SetPosition(2, Holder.position + Holder.right * 0.05f);



            isMoving = false;

            // ShootingAngle = (InitPosition.localPosition - CurrentShooter.transform.localPosition).normalized;



            power = (OriginalHolderPos - CurrentShooter.transform.localPosition).magnitude;


            shooterRB.isKinematic = false;

            shooterRB.useGravity = true;

           

            shooterRB.AddForce(transform.TransformVector(ShootingAngle) * power * PowerFactor);

            CurrentShooter.GetComponent<ShooterScript>().shot();


            if (currentTouch.y > yMax - 50)
            {
                CurrentShooter.transform.position = OrigihnalPos;
            }

            isShooterCreated = false;

            Invoke("InstShooter", 2);

        }


        if (isMoving)
        {

           // print(currentTouch);

            yMin = Screen.height * 0.1f;
            yMax = Screen.height * 0.5f;

            Vector3 clampedTouch = new Vector3(currentTouch.x, Mathf.Clamp(currentTouch.y, yMin, yMax), OriginalHolderPos.z - (touchPosition.y - Mathf.Clamp(currentTouch.y, yMin, yMax)) * 2 / Screen.height);
            //print(clampedTouch);

            distance = 1f;

            //CurrentShooter.transform.position = Vector3.MoveTowards(Holder.position, myCamera.ScreenToWorldPoint(clampedTouch), distance);
            Holder.transform.position = myCamera.ScreenToWorldPoint(clampedTouch);

            lineRenderer.SetPosition(1, Holder.position + Holder.right * 0.05f);
            lineRenderer.SetPosition(2, Holder.position - Holder.right * 0.05f);
            ///////////////////
            ShootingAngle = (OriginalHolderPos - CurrentShooter.transform.localPosition).normalized;
            Acceleration = ((Holder.position - CurrentShooter.transform.position).magnitude * ShootingAngle * PowerFactor) / shooterRB.mass;

            PlayerPos = CurrentShooter.transform.position;
           


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
        if (isShooterCreated == false) { 
        CurrentShooter = Instantiate(Shooter, Holder.position + Vector3.forward * 0.2f, transform.rotation, Holder);
        OrigihnalPos = CurrentShooter.transform.position;
            CurrentShooter.GetComponent<ShooterScript>().OnDestroyed = OnShooterDestroyed;

        shooterRB = CurrentShooter.GetComponent<Rigidbody>();
        isShooterCreated = true;
    } }

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

            Holder.transform.position = Vector3.MoveTowards(Holder.transform.position, OriginalHolderPos, Time.deltaTime * shooterRB.velocity.magnitude);

            lineRenderer.SetPosition(1, Holder.position + Holder.right * 0.05f);
            lineRenderer.SetPosition(2, Holder.position - Holder.right * 0.05f);
            //lineRenderer.SetPosition(1, OriginalHolderPos);
            yield return null;
        }
    }


}
