using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public Button playButton;
    public Toggle IsMale;
    public Toggle IsFemale;

    public Text ShowMsgError;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(ToGameScene);

    }

    // Update is called once per frame
    void Update()
    {

    }


    void ToGameScene()
    {

        if (IsMale.isOn)
        {
            MoveToScenea();
        }
        else if (IsFemale.isOn)

        {
            MoveToScenea();
        }
        else
        {
            ShowMsgError.text = "Plase select Gender";
        }
    }
     

         
    void MoveToScenea()
    {
        SceneManager.LoadScene("GameScene");
        ShowMsgError.text = "";
    }


    public void SoundOn()
    {

        AudioScript.Instance.ToggleMuteSound();
    }



}