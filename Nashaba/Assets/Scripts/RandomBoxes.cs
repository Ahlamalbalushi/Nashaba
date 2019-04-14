using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoxes : MonoBehaviour
{
    public GameObject[] boxesSpawn;
    public Transform boxPosition1;
    public Transform boxPosition2;

    int randomInt;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SpownRandom();
        }
    }

    void SpownRandom()
    {
        randomInt = Random.Range(0, boxesSpawn.Length);
        Instantiate(boxesSpawn[randomInt], boxPosition1.position, boxPosition1.rotation);
        Instantiate(boxesSpawn[randomInt], boxPosition2.position, boxPosition2.rotation);
    }
}
