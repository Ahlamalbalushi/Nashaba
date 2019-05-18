using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScript : MonoBehaviour
{
    public Text CurrScore;
    public Text TotalScore;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Levels.LevelNumber == 1)
            CurrScore.text = ScoreCollection.Score[0].ToString();
        else if (Levels.LevelNumber == 2)
            CurrScore.text = ScoreCollection.Score[1].ToString();
        else if (Levels.LevelNumber == 3)
            CurrScore.text = ScoreCollection.Score[2].ToString();


        TotalScore.text = ScoreCollection.TotalScore.ToString();

    }
}

