using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public Button playButton;
    public Text ShowMsgErrorText;

    public Toggle SettingBtn;
    public GameObject SoundBtnObj;
    //  public Button SoundBtn;
    public Button ExitBtn;


    public GameObject Gender;
    public Toggle IsMale;
    public Toggle IsFemale;

    public GameObject low_boy;
    public GameObject low_Gail;



    // Start is called before the first frame update
    void Start()
    {
        HideObj();
        playButton.onClick.AddListener(ToGameScene);
        //SoundBtn.onClick.AddListener(SoundPlay);
        ExitBtn.onClick.AddListener(QuitApp);

    }

    // Update is called once per frame
    void Update()
    {
        clickSetting();

    }


    void ToGameScene()
    {
        // AudioScript.Instance.PlaySound("ClickBtn");

        if (IsMale.isOn || IsFemale.isOn)
        {
            MoveToScenea();
        }
        else
        {
            ShowObjError();

        }
    }



    void clickSetting()
    {

        if (SettingBtn.isOn)
        {
            SoundBtnObj.SetActive(true);
        }
        else
        { SoundBtnObj.SetActive(false); }

    }



    void QuitApp() { Application.Quit(); }


    void HideObj()
    {
        ShowMsgErrorText.enabled = false;
        Gender.gameObject.SetActive(true);
        low_boy.gameObject.SetActive(false);
        low_Gail.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        SoundBtnObj.SetActive(false);
       // slider.gameObject.SetActive(false);

    }


    void ShowObjError()
    {
        ShowMsgErrorText.enabled = true;
        ShowMsgErrorText.text = "Plase select Charater";
    }


    void HideObjAfterSelectChar()
    {
        Gender.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        ShowMsgErrorText.enabled = false;
        SettingBtn.gameObject.SetActive(false);
        ExitBtn.gameObject.SetActive(false);
        SoundBtnObj.SetActive(false);

    }



    void MoveToScenea()
    {

       for (int TimerMovScen = 0; TimerMovScen <= 2; TimerMovScen++)
        {

            if (IsMale.isOn)
            {
                low_boy.gameObject.SetActive(true);
                low_Gail.gameObject.SetActive(false);
                HideObjAfterSelectChar();


            }
            else if (IsFemale)
            {
                low_boy.gameObject.SetActive(false);
                low_Gail.gameObject.SetActive(true);
                HideObjAfterSelectChar();
            }

            SceneManager.LoadScene("Levels");

        }

    }



    public void SoundOn()
    {
        AudioScript.Instance.ToggleMuteSound();
    }



}

