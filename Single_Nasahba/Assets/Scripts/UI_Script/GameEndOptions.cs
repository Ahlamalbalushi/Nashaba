using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndOptions : MonoBehaviour
{

   // public static GameEndOptions Instance;


    public Button BackToLevelBtn;
    public Button NextLevelBtn;
    public int unloacked = 0;

    // public static int unloackedValue;


  /*  void Awake()

    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(gameObject);
    }
    */


    void Start()
    {

        BackToLevelBtn.onClick.AddListener(BackToLevel);

        NextLevelBtn.onClick.AddListener(NextLevel);


      /* if (GameObject.FindWithTag("Food") == null)
          {
              if (Levels.LevelNumber == 1)
              {
                  unloacked = 1;
                  Levels.LevelNumber = 2;
              }
              else if (Levels.LevelNumber == 2)
              {
                  unloacked = 2;
                  Levels.LevelNumber = 3;
            }
            
        }
         
        */


        /*
        if (Levels.LevelNumber == 1)
        {

            if (GameObject.FindWithTag("Food") == null)
            {
                unloacked = 1;
                Levels.LevelNumber = 2;

            }

        }

        else if (Levels.LevelNumber == 2)
        {
            if (GameObject.FindWithTag("Food") == null)
            {
                unloacked = 2;
                Levels.LevelNumber = 3;
            }
        }

        */




    }


    void BackToLevel()
    {
        AudioScript.Instance.PlaySound("ClickBtn");
        SceneManager.LoadScene("Levels");
    }



    public void NextLevel()
    {
        AudioScript.Instance.PlaySound("ClickBtn");

        CheckToGoNextLevel();
    }



    public void CheckToGoNextLevel()
    {

        if (GameObject.FindWithTag("Food") == null)
        {
            if (Levels.LevelNumber == 1)
            {
                unloacked = 1;
                Levels.LevelNumber = 2;
            }

            else if (Levels.LevelNumber == 2)
            {
                unloacked = 2;
                Levels.LevelNumber = 3;
            }
            SceneManager.LoadScene("Game");

        }
        else
        { SceneManager.LoadScene("Game"); }





        /*
   
    if (Levels.LevelNumber == 1) 
    {

        if (GameObject.FindWithTag("Food") == null)
        {
            unloacked = 1;
            Levels.LevelNumber = 2;           
            SceneManager.LoadScene("Game");  
        }

        else
        { SceneManager.LoadScene("Game"); }

    }

    else if (Levels.LevelNumber == 2)
    {

        if (GameObject.FindWithTag("Food") == null)
        {
            unloacked = 2;
            Levels.LevelNumber = 3;
            SceneManager.LoadScene("Game");    
        }
        else
        { SceneManager.LoadScene("Game"); }

    }
    */






    }
}