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

    //AsyncOperation async;
    // public Slider slider;
    // public GameObject LoadingPart;
    // public Text TextIndicator;

    //public GameObject HideLevel2;
    // public GameObject HideLevel3;

    // bool IsHide;

    public GameEndOptions GameEndOptions;

    void Start()
    {

        Level1.onClick.AddListener(delegate { LoadLevels(1); });
        Level2.onClick.AddListener(delegate { LoadLevels(2); });
        Level3.onClick.AddListener(delegate { LoadLevels(3); });

        Level2.interactable = false;
        Level3.interactable = false;


        if (GameEndOptions.unloacked == 0)
        {
            Level2.interactable = false;
            Level3.interactable = false;
        }
        if (GameEndOptions.unloacked == 1)
        {
            Level2.interactable = true;
            Level3.interactable = false;
        }
        if (GameEndOptions.unloacked == 2)
        {
            Level2.interactable = true;
            Level3.interactable = true;
        }


        /*

        if (GameEndOptions.Instance.unloacked == 0)
        {
            Level2.interactable = false;
            Level3.interactable = false;
        }
        if (GameEndOptions.Instance.unloacked == 1)
        {
            Level2.interactable = true;
            Level3.interactable = false;
        }
        if (GameEndOptions.Instance.unloacked == 2)
        {
            Level2.interactable = true;
            Level3.interactable = true;
        }
       
        */

    }

    public void LoadLevels(int LevelIndex)
    {
       AudioScript.Instance.PlaySound("ClickBtn");
        LevelNumber = LevelIndex;
        // StartCoroutine("Wait");
        SceneManager.LoadScene("Game");

    }




    void Update()
    {

    }
}


