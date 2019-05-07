using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Levels : MonoBehaviour
{

    public Button Level1;
    public Button Level2;
    public Button Level3;

    //user to declare level number (other Scene)
    static public int LevelNumber;


    void Start()
    {
        Level1.onClick.AddListener(delegate { LoadLevels(1); });
        Level2.onClick.AddListener(delegate { LoadLevels(2); });
        Level3.onClick.AddListener(delegate { LoadLevels(3); });
    }



    public void LoadLevels(int LevelIndex)
    {
        SceneManager.LoadScene("Game");
        LevelNumber = LevelIndex;

    }



}


