using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGame : MonoBehaviour
{ 

    public Button GameExit;

   // public GameObject box1;
   // public GameObject box2;
    //public GameObject box3;


   // public int IsCreate = 1 ;
    // Start is called before the first frame update
    void Start()
    {

        GameExit.onClick.AddListener(GameExitLevel);
    }


    void GameExitLevel()
    { SceneManager.LoadScene("Levels"); }

    void Update()
    {
        //print vlaue from other Scene
       // print(Levels.LevelNumber);


        /*
        if(Levels.LevelNumber==1)
        {
            if (IsCreate <= 1)
            {
                Instantiate(box1,new Vector3(0,2,0), Quaternion.identity);
                IsCreate--;
            }
        }
        else if (Levels.LevelNumber == 2)
        {
            if (IsCreate <= 1)
            {
                Instantiate(box2, new Vector3(0, 2, 0), Quaternion.identity);
                IsCreate--;
            }
        }
        else if (Levels.LevelNumber == 3)
        {
            if (IsCreate <= 1)
            {
                Instantiate(box3, new Vector3(0, 2, 0), Quaternion.identity);
                IsCreate--;
            }
        }

    */

    }









}



