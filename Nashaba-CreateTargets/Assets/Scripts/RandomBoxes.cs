using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomBoxes : MonoBehaviour
{
    public GameObject[] boxesSpawn;
    public Transform boxPosition;

    int randomInt;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpownRandom();
        }
    }

    void SpownRandom()
    {
        randomInt = Random.Range(0, boxesSpawn.Length);
        Instantiate(boxesSpawn[randomInt], boxPosition.position, boxPosition.rotation);
    }
}
