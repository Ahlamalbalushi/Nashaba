using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public Button playButton;

    public Image Msgbox;
    public Text ShowMsgErrorText;
    public Button CancelBtn;
    public Toggle IsMale;
    public Toggle IsFemale;
    public Image PlayerImg;

   

    // Start is called before the first frame update
    void Start()
    {
        HideObj();

        playButton.onClick.AddListener(ToGameScene);
        CancelBtn.onClick.AddListener(HideObj);
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
            PlayerImg.color = Color.blue;

        }
        else if (IsFemale.isOn )
        {
          
            MoveToScenea();
            PlayerImg.color = Color.red;
            

        }
        else
        {
            ShowObjError();
        }
    }
     
  
    

    void HideObj()
    {
        Msgbox.enabled = false;
        ShowMsgErrorText.enabled = false;
        CancelBtn.gameObject.SetActive(false);
        PlayerImg.enabled = false;
        ShowMsgErrorText.text = "";
    }


    void ShowObjError()
    {
        Msgbox.enabled = true;
        ShowMsgErrorText.enabled = true;
        CancelBtn.gameObject.SetActive(true);
        ShowMsgErrorText.text = "Plase select Gender";
    }


    void ShowObjCorrect()
    {
        Msgbox.enabled = true;
        PlayerImg.enabled = true;
    }



    void MoveToScenea()
    {
        for (int TimerMovScen = 0; TimerMovScen <=100; TimerMovScen++)
        {
            ShowObjCorrect();
            SceneManager.LoadScene("GameScene");
        }
    }


    public void SoundOn()
    {
        AudioScript.Instance.ToggleMuteSound();
    }



}