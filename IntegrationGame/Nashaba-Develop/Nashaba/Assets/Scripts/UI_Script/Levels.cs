using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{


    public static Levels Instance;

     public Button Level1;
     public Button Level2;
     public Button Level3;

    public int LevelNumber = 1;


  

    void Awake()

     {
         if (Instance == null)
             Instance = this;
         else
             Destroy(this);

         DontDestroyOnLoad(gameObject);
     }


    // Start is called before the first frame update
    void Start()
    {

        Level1.onClick.AddListener(LevelOne);
        Level2.onClick.AddListener(LevelTwo);
        Level3.onClick.AddListener(LevelThree);

     
          
    }


    void LevelOne()
        {
            LevelNumber = 1;
            SceneManager.LoadScene("GameLevels");
        }

        void LevelTwo()
        {
            LevelNumber = 2;
            SceneManager.LoadScene("GameLevels");
        }

        void LevelThree()
        {
            LevelNumber = 3;
            SceneManager.LoadScene("GameLevels");

        }




    }




