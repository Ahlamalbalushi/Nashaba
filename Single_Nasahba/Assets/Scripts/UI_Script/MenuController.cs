using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{


    public static bool hideExitBtn = true;

    public Button playButton;
    public Text ShowMsgErrorText;
    public Toggle SettingBtn;
    public GameObject SoundBtnObj;
    public GameObject soundoff;
    public GameObject soundon;


    //  public Button SoundBtn;
    // public Button BackChacterbtn;

    public GameObject Gender;
    public Toggle IsMale;
    public Toggle IsFemale;


    public static int SelectCharachetr;
    public GameObject low_boy;
    public GameObject low_Gail;
    bool ShowSoundBtn = true;
    public GameObject ExitBtn ;

    // float TimerSoundBtn = 3;




     void Awake()
    {
        //AudioScript.Instance.PlaySound("StartGame");

    }
    // Start is called before the first frame update
    void Start()
    {

        HideObj();
        playButton.onClick.AddListener(ToGameScene);
        //SoundBtn.onClick.AddListener(SoundPlay);
       // BackChacterbtn.onClick.AddListener(BackChacterSetting);


    }

    // Update is called once per frame
    void Update()
    {
        //AudioScript.Instance.PlaySound("StartGame");
        clickSetting();

    }


    void ToGameScene()
    {

        if (IsMale.isOn || IsFemale.isOn)
        {
            AudioScript.Instance.PlaySound("ClickBtn");
            MoveToScenea();
        }
        else
        {
            AudioScript.Instance.PlaySound("smsalert");
            ShowObjError();

        }

    }



    void clickSetting()
    {

        if (SettingBtn.isOn )
        {
            AudioScript.Instance.PlaySound("ClickBtn");
            SoundBtnObj.SetActive(true);  
                 
        }
        else
        {
            AudioScript.Instance.PlaySound("ClickBtn");
            SoundBtnObj.SetActive(false); 
        }


       
    }


  /* void BackChacterSetting()
    {
        AudioScript.Instance.PlaySound("ClickBtn");
        SceneManager.LoadScene("Levels");
        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
        //Application.LoadLevel(Application.loadedLevel);
    }

    */





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
        //ExitBtn.gameObject.SetActive(false);
        ExitBtn.SetActive(false);
        soundon.SetActive(false);
        soundoff.SetActive(false);
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
                SelectCharachetr = 0;


            }
            else if (IsFemale)
            {
                low_boy.gameObject.SetActive(false);
                low_Gail.gameObject.SetActive(true);
                HideObjAfterSelectChar();
                SelectCharachetr = 1;

            }

            SceneManager.LoadScene("Levels");
            print("sawsan go up ");
        }

    }


  


    public void SoundOn()
    {
        // TimerSoundBtn = 3;
        AudioScript.Instance.PlaySound("ClickBtn");
        AudioScript.Instance.ToggleMuteSound();
    }



}

