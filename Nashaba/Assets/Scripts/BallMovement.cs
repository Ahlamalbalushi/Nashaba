﻿using System.Collections;
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

    private void Start()
    {
        GameObject go = GameObject.Find("WayPoints");
        WayPoints = go.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wayPointDirection = (WayPoints[index].position - transform.position).normalized;
        if (Vector3.Distance(transform.position, WayPoints[index].position) < 1f)
        {
            index++;
            if (WayPoints.Length == index)
                index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(-2500 * transform.up);
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


            if (collision.gameObject.tag == "Target")   
                Score++;
                scoreText.text = " Score : " + Score;
                print(Score);            
        }
    }
}

