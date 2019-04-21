using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    bool move = false;


    // for scores 
    public Text scoreText;
    int Score = 0;
    bool isHit = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            print(" MY Score is: " + Score);
            if (isHit == true)
            {
                Score++;
                scoreText.text = " Score : " + Score;
                isHit = false;
               
            }
        }
    }

    public void Hit()
    {
        print("Hit");
        isHit = true;
    }

}
