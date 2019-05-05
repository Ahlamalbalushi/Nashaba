using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShooterScript : MonoBehaviour
{

    public Action clicked;
    public GameObject smoke;
    bool doit = true;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(3500 * transform.up);
           
        }


    }

    public void shot()
    {

        Invoke("ShooterDestroyed", 3);

    }

    void ShooterDestroyed()
    {
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        clicked.Invoke();
        
    }

    void destroythissmoke()
    {
        Destroy(this.gameObject);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Instantiate(smoke, this.transform.position, Quaternion.identity);
            //doit = false;
            //print("Colid");
        }
    }
     

         
    
}
