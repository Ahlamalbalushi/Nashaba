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
    bool doit = true;

    public Transform[] WayPoints;
    Vector3 tempWayPoint;
    int index = 0;
    bool isCrashed;

    // for resize the player 

    Rigidbody myRB;
    public float Speed = 5;
    public float TurnSpeed = 5;


    private void Start()
    {
        // for resize  player
        myRB = GetComponent<Rigidbody>();

        GameObject go = GameObject.Find("WayPoints");
        // WayPoints = go.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (isCrashed = true)
        //{
        // Vector3 wayPointDirection = (WayPoints[index].position - transform.position).normalized;
        //if (Vector3.Distance(transform.position, WayPoints[index].position) < 1f)
        //{
        //    index++;
        //    if (WayPoints.Length == index)
        //        index = 0;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(-Speed * transform.up);
            isPlayerDied = true;
        }
    }
        //    if (isPlayerDied)
        //    {
        //        Invoke("destroythissmoke", 5);
        //    }

        //}
        //    void destroythissmoke()
        //    {
        //        Destroy(this.gameObject);
        //    }

        private void OnCollisionEnter(Collision collision)
        {

            if (collision.gameObject.tag == "Target")
                Score++;
            scoreText.text =""+ Score;
        if (collision.gameObject.tag == "Danger_Box")
            Score--;
        scoreText.text = "" + Score;
            print(Score);

            //  for resize player

        //    transform.localScale += new Vector3(0.5F, 0.5f, 0.5f);
        }

        //if(!isCrashed)
        //{
        //    print("it is not crashed");
        //}
    }


