using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{

    public Button GameExit;


    void Start()
    {
        GameExit.onClick.AddListener(GameExitLevel);

    }

    void GameExitLevel()
    {
        SceneManager.LoadScene("Levels");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

        //Application.LoadLevel(Application.loadedLevel);
    }



}
