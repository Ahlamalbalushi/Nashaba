using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsStart : MonoBehaviour
{

    public GameObject Ships1;
    public GameObject Ships2;
    public GameObject Ships3;



    // Start is called before the first frame update
    void Start()
    {
        Ships1.SetActive(false);
        Ships2.SetActive(false);
        Ships3.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(Levels.LevelNumber==1)
        {

            if (ScoreCollection.Score[0] == 10)
            {
                Ships1.SetActive(true);
            }
            if (ScoreCollection.Score[0] == 20)
            {
                Ships2.SetActive(true);
            }
            if (ScoreCollection.Score[0] == 30)
            {
                Ships3.SetActive(true);
            }

        }
       else if (Levels.LevelNumber == 2)
        {

            if (ScoreCollection.Score[1] == 30)
            {
                Ships1.SetActive(true);
            }
            if (ScoreCollection.Score[1] == 60)
            {
                Ships2.SetActive(true);
            }
            if (ScoreCollection.Score[1] == 90)
            {
                Ships3.SetActive(true);
            }

        }
        else if (Levels.LevelNumber == 3)
        {

            if (ScoreCollection.Score[2] == 50)
            {
                Ships1.SetActive(true);
            }
            if (ScoreCollection.Score[2] == 100)
            {
                Ships2.SetActive(true);
            }
            if (ScoreCollection.Score[2] == 150)
            {
                Ships3.SetActive(true);
            }

        }


    }
}
