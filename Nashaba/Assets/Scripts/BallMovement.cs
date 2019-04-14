using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * 20 * Time.deltaTime);  
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "FirstTarget")
    //    {
    //        print("destroy first");
    //        Destroy(other.gameObject);
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Destroy")
    //    {
    //        print("destroy first");
    //        Destroy(gameObject);
    //    }
    //}
}
