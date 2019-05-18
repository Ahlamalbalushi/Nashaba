using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveTocharacter : MonoBehaviour
{
    public Button CharacterScene;


     void Awake()
    {
// // //        AudioScript.Instance.PlaySound("Levels");
    }
    void Start()
    {
        CharacterScene.onClick.AddListener(MoveToCharacterScene);

    }

    void MoveToCharacterScene()
    {
        AudioScript.Instance.PlaySound("ClickBtn");
        SceneManager.LoadScene("Menu");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

        //Application.LoadLevel(Application.loadedLevel);
    }



}
