using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    public Button BackToMenus;


    void Start()
    {
        BackToMenus.onClick.AddListener(Menu);

    }

    void Menu()
    {
        SceneManager.LoadScene("Menu");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

        //Application.LoadLevel(Application.loadedLevel);
    }



}
