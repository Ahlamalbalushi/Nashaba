using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    bool move = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //move = true;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce( -3000 * transform.up);

        }

        //if (move)
        //{
        //    transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        //}
    }

}
