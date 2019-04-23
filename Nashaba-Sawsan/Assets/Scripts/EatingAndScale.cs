using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingAndScale : MonoBehaviour
{



    public float Speed = 5;
  
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.UpArrow))
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+Speed*Time.deltaTime);


        if (Input.GetKey(KeyCode.DownArrow))
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z- Speed * Time.deltaTime);



        if (Input.GetKey(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);


        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
    }


   

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag== "Cake")
        {
            AudioScript.Instance.PlaySound("EatingFood");

            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "Box")
        {
            AudioScript.Instance.PlaySound("TimerTick");
            transform.localScale = new Vector3(1F, 1f,1f);
            Destroy(other.gameObject);
        }




    }


}
