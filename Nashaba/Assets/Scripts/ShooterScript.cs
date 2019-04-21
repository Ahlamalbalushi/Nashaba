using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShooterScript : MonoBehaviour
{

    public Action clicked;
   

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
    }


    private void OnMouseDown()
    {
        clicked.Invoke();

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            print("Colid");
        
           
        }
    }
}
