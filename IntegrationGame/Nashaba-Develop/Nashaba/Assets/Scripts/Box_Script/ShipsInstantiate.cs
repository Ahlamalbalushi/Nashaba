using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipsInstantiate : MonoBehaviour
{
    public GameObject[] shipsSpawn;
    public Transform shipsPosition;
    public float Speed = 100; 
    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpownRandom();
            print("my ships");
            GetComponent<Rigidbody>().AddForce(-Speed * transform.up);
        }
        
    }

    void SpownRandom()
    {
        randomInt = Random.Range(0, shipsSpawn.Length);
        Instantiate(shipsSpawn[randomInt], shipsPosition.position, shipsPosition.rotation);
}
}
