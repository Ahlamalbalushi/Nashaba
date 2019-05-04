using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    int Score=100000;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level2",1);
        PlayerPrefs.SetInt("Level1_Score", Score);

        StartCoroutine(Time());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
        Application.LoadLevel(4);
    }
}
