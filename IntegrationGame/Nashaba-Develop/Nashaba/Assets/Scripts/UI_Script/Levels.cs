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

   // public string LevelName="LeveL";
   



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


   public void LevelOne()
    {
        LevelNumber = 1;
        MoveToGameScene();


    }

    public void LevelTwo()
    {
//        Application.LoadLevel(Application.loadedLevel);
        LevelNumber = 2;
        MoveToGameScene();


    }

    public void LevelThree()
    {
        LevelNumber = 3;
        MoveToGameScene();
       

    }


    void MoveToGameScene()
    {
        //LevelName = LevelName + LevelNumber;
        SceneManager.LoadScene("Game");

    }





}


