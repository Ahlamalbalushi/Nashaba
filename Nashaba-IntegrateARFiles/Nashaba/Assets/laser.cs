using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    //private LineRenderer lr;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    lr = GetComponent<LineRenderer>();
    //    lr.enabled = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    lr.SetPosition(0, transform.position);

    //    RaycastHit hit;
    //    lr.enabled = true;

    //    if (Input.GetMouseButtonUp(0))
    //    {

    //        if (Physics.Raycast(transform.position, transform.forward, out hit))
    //        {

    //            if (hit.collider)
    //            {
    //              //  lr.SetPosition(1, hit.point);
    //                lr.SetPosition(1, transform.forward * 10 + new Vector3(0, 1, 0));
    //            }
    //        }
    //        else
    //        { lr.SetPosition(1, transform.forward * 5000); }
    //    }
    //}



    //public float length = 10f;
    ////player=kogel
    //public GameObject Shooter;
    //public int snelheid = 50;
    //public Transform mandjes;
    //public Rigidbody projectile;
    //public bool draaien = true;
    //public float shoottimer = 0;
    ////box=target
    //public Transform Box;
    //public Transform laserlicht;

    //LineRenderer lineRenderer;
    //// Use this for initialization
    //void Start()
    //{
    //    lineRenderer = GetComponent<LineRenderer>();
    //    lineRenderer.enabled = true;
    //}

    //// Update is called once per frame
    //void Update()
    //{

    
    //    transform.Rotate(0, 10 * Time.deltaTime, 0);

    //    //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    //    //Debug.DrawRay(transform.position, transform.forward * length, Color.green);

    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, length))
    //    {
    //        lineRenderer.SetPosition(0, transform.position);
    //        lineRenderer.SetPosition(1, hit.point);
    //        laserlicht.transform.position = hit.point;


    //        if (hit.collider.tag == "Player")
    //        {
    //            transform.LookAt(Box);
    //            shoottimer += 2.0f * Time.deltaTime;
    //            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

    //        }
    //        if (shoottimer > 1f)
    //        {
    //            Rigidbody clone;
    //            clone = Instantiate(projectile, mandjes.position, mandjes.rotation) as Rigidbody;
    //            clone.velocity = transform.TransformDirection(Vector3.forward * snelheid);
    //            shoottimer = 0f;

    //        }

    //    }
    //    else
    //    {

    //        lineRenderer.SetPosition(0, transform.position);
    //        lineRenderer.SetPosition(1, transform.forward * length);
    //    }

    //}




}
