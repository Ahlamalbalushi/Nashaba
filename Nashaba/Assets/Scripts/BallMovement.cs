using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{

    // for scores 
    public Text scoreText;
    public int Score = 0;

    // for create player
    public GameObject[] PlayerSpawn;
    public Transform playerPosition;
    int players;

    bool isPlayerDied = false;

    public GameObject smoke;
    bool doit =true;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce( -2500 * transform.up);
            isPlayerDied = true;

        }


        if (isPlayerDied)
        {
            Invoke("destroythissmoke", 5);
        }

        }


void destroythissmoke()
{
    Destroy(this.gameObject);
}


private void OnCollisionEnter(Collision collision)
    {

        if (doit)
        { 
        Instantiate(smoke, this.transform.position, Quaternion.identity);
            doit = false;
        }

        Score++;
        scoreText.text = " Score : " + Score;
        if (collision.gameObject.tag == "Target")
        {
           
            print(Score);
        }
    }
}
