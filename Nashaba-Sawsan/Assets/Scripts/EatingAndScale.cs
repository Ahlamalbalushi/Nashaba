using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingAndScale : MonoBehaviour
{



    Rigidbody myRB;
    public float Speed = 5;
    public float TurnSpeed = 5;
  
   
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horizontalVelocity = transform.forward * Speed * Input.GetAxis("Vertical");
        horizontalVelocity.y = myRB.velocity.y;

        myRB.velocity = horizontalVelocity;

        myRB.angularVelocity = new Vector3(0, Input.GetAxis("Horizontal") * TurnSpeed, 0);


    }


   

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag== "Cake")
        {
            transform.localScale += new Vector3(0.5F, 0.5f, 0.5f);

            print("Scale Increace");
        }

    }


}
