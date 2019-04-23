using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    //public GameObject[] food;
    //int myFood;
    float degrees = 90;
    bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onGround)
        {
            // transform.Rotate(Vector3.up, degrees * Time.deltaTime * 1);

            Vector3 food = new Vector3(degrees * Time.deltaTime, 0, 0);

            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, food, Time.deltaTime * 0.5f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            onGround = true;
        }
    }
}
