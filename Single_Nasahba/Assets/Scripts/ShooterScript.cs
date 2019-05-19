using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShooterScript : MonoBehaviour
{
    public GameObject smoke;
    public GameObject ships;
    //bool doit = true;

    public Action OnDestroyed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void shot()
    {

        Invoke("ShooterDestroyed", 3);

    }

    void ShooterDestroyed()
    {
        Destroy(gameObject);
        OnDestroyed.Invoke();
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
        }

        if(collision.gameObject.tag == "chips")
        {
            Instantiate(ships, this.transform.position, Quaternion.identity);
        }
    }
     
    
    
}
