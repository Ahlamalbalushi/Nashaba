using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollection : MonoBehaviour
{
    Vector3 ScaleOriginal;

    public static int [] Score = new int[3];
   // public static int Score;
    public static int TotalScore;

    //public static int Score;
    // public static string desTag ;

    //  public List<int> Score = new List<int>();
    //public static int TotalScore;
    //int Add_Score;

    void Start()
    {

    }


    void Update()
    {
        ScaleOriginal = transform.localScale;


    }


  
    public void OnCollisionEnter(Collision collision)
    {

       if (collision.gameObject.tag == "Target")
        {
            AudioScript.Instance.PlaySound("DestoryBox2");
        }


        if (collision.gameObject.tag == "Food")
        {

            if (Levels.LevelNumber == 1)
            {
                Score[0] += 10;
                TotalScore = Score[0];
            }
            else if (Levels.LevelNumber == 2)
            {
                Score[1] += 30;
                TotalScore = Score[0] + Score[1];
            }
            else if (Levels.LevelNumber == 3)
            {
                Score[2] += 50;
                TotalScore = Score[0] + Score[1] + Score[2];
            }

            collision.gameObject.SetActive(false);
           // Score += 100;
           // transform.localScale += new Vector3(5f, 5f, 5f);
        }


        if (collision.gameObject.tag == "Danger_Box")
        {
            AudioScript.Instance.PlaySound("DendgersTimer");
            transform.localScale = ScaleOriginal;
        }


    }
    
}
