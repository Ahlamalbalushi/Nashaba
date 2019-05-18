using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.Common;
using System;
#if UNITY_EDITOR
// Set up touch input propagation while using Instant Preview in the editor.
using Input = GoogleARCore.InstantPreviewInput;
#endif

public class threedNashaba : MonoBehaviour
{



    public GameObject SmsEndGame;

    // Start is called before the first frame update
    public GameObject SelectBoy;//0
    public GameObject Selectgail;//1

     GameObject Shooter;
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
    public LineRenderer lineRenderer;

    public Transform Holder;
    public HolderScript HolderScript;

    Vector3 OriginalHolderPos;
    Vector3 originalHolderRotaion;
    public Vector3 Acceleration;

    public Vector3 PlayerPos;


  

    public GameObject Live5M;
    public GameObject Live4M;
    public GameObject Live3M;
    public GameObject Live2M;
    public GameObject Live1M;

    public GameObject Live5F;
    public GameObject Live4F;
    public GameObject Live3F;
    public GameObject Live2F;
    public GameObject Live1F;
    public bool OneTimeCreateLive=true;
    public static int Live;
   //public Button LiveBtn;
   // public static int Live;

    // Start is called before the first frame update
    public void Start()
    {
        //LiveBtn.onClick.AddListener(Add5Live);
        // LiveBtn.onClick.AddListener(Add3Live);
        power = 0;
        Live = 6;
        HolderScript.clicked = ShooterCLicked;
        setShooter();
        OriginalHolderPos = Holder.localPosition;
        //originalHolderRotaion = nashababody.rotation;
        //print("rotaion" + nashababody.transform.localPosition);

       
    }


    // Update is called once per frame
    public void Update()
    {


        if (MenuController.SelectCharachetr == 0 && OneTimeCreateLive)
        {
          
            Live5F.SetActive(true);
            Live4F.SetActive(true);
            Live3F.SetActive(true);
            Live2F.SetActive(true);
            Live1F.SetActive(true);
            OneTimeCreateLive = false;
        }
        else if (MenuController.SelectCharachetr == 1 && OneTimeCreateLive)
        {
           
            Live5M.SetActive(true);
            Live4M.SetActive(true);
            Live3M.SetActive(true);
            Live2M.SetActive(true);
            Live1M.SetActive(true);
            OneTimeCreateLive = false;

        }



        currentTouch = Input.mousePosition;

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
            if (currentTouch.y > yMax - 50)
            {
                CurrentShooter.transform.position = OrigihnalPos;

            }

            isShooterCreated = false;
            Invoke("InstShooter", 2);
        }

        if (isMoving)
        {

            yMin = Screen.height * 0.1f;
            yMax = Screen.height * 0.5f;

            float yoffset =  currentTouch.y - touchPosition.y;

            Vector3 clampedTouch = new Vector3(currentTouch.x, Mathf.Min(currentTouch.y + yoffset, yMax), OriginalHolderPos.z - (touchPosition.y - Mathf.Clamp(currentTouch.y, yMin, yMax)) * 0.2f / Screen.height);
            distance = 0.1f;
            Holder.transform.position = myCamera.ScreenToWorldPoint(clampedTouch);
            lineRenderer.SetPosition(1, Holder.localPosition + Vector3.right * 0.005f);
            lineRenderer.SetPosition(2, Holder.localPosition - Vector3.right * 0.005f);


            // Vector3 rot = (OriginalHolderPos - Holder.transform.localPosition).normalized;
            // nashababody.transform.position = new Vector3(nashababody.transform.position.z, ( Holder.transform.localPosition.y), nashababody.transform.position.z) ;

            // if (currentTouch.x != 0)
            // {
            float XPosition = (currentTouch.x - Screen.width / 2);
            print("XPosition" + XPosition);
            XPosition /= (Screen.width / 2);
            // print("xposition" + XPosition);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -(XPosition) * 15, transform.localEulerAngles.z);
            //nashababody.transform.eulerAngles = new Vector3(nashababody.transform.eulerAngles.x, (nashababody.transform.eulerAngles.y - currentTouch.x) * 0.05f, nashababody.transform.eulerAngles.z);
            //}
            // print("holder " + Holder.transform.localPosition);

            ;

            ShootingAngle = transform.TransformVector((OriginalHolderPos - Holder.transform.localPosition).normalized);
            Acceleration = (ShootingAngle * (OriginalHolderPos - Holder.transform.localPosition).magnitude * PowerFactor) / shooterRB.mass;
            PlayerPos = CurrentShooter.transform.position;


            // vibrate for phone
            Handheld.Vibrate();
            // AudioScript.Instance.PlaySound("TimerTick");
           AudioScript.Instance.PlaySound("Shooting2");


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


            if (MenuController.SelectCharachetr == 0)
            {
                Shooter = SelectBoy;
            }
            else if (MenuController.SelectCharachetr == 1)
            {
                Shooter = Selectgail;
            }



                CurrentShooter = Instantiate(Shooter, Holder.position + Holder.forward * 0.02f, transform.rotation, Holder);
                OrigihnalPos = CurrentShooter.transform.position;
                CurrentShooter.GetComponent<ShooterScript>().OnDestroyed = OnShooterDestroyed;
                shooterRB = CurrentShooter.GetComponent<Rigidbody>();
                isShooterCreated = true;

                 Live--;

            if (Live == 4)
            {
                Live5F.SetActive(false);
                Live5M.SetActive(false);
            }
            else if (Live == 3)
            {
                Live4F.SetActive(false);
                Live4M.SetActive(false);
            }
            else if (Live == 2)
            {
                Live3F.SetActive(false);
                Live3M.SetActive(false);
            }
            else if (Live == 1)
            {
                Live2F.SetActive(false);
                Live2M.SetActive(false);
            }
            else if (Live == 0)
            {
                Live1F.SetActive(false);
                Live1M.SetActive(false);

                for (int i = 0; i <= 5 + Time.deltaTime; i++)
                {
                    if (i <= 5)
                        SmsEndGame.SetActive(true);
                }

            }

        }


    }



    public void OnShooterDestroyed()
    {
        if (Live>0)
        { setShooter();}
        else
        { Destroy(CurrentShooter);}
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
            lineRenderer.SetPosition(1, Holder.localPosition + Vector3.right * 0.005f);
            lineRenderer.SetPosition(2, Holder.localPosition - Vector3.right * 0.005f);
            //lineRenderer.SetPosition(1, OriginalHolderPos);
            yield return null;
        }
    }


}
