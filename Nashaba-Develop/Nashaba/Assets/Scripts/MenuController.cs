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
        CancelBtn.onClick.AddListener(HideObj);
    }

    // Update is called once per frame
    void Update()
    {
     

    }

    void ToGameScene()
    {
        AudioScript.Instance.PlaySound("ClickBtn");

        if (IsMale.isOn || IsFemale.isOn)
        {
            MoveToScenea();
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
        ShowMsgErrorText.text = "";
        Gender.gameObject.SetActive(true);
        low_boy.gameObject.SetActive(false);
        low_Gail.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);

    }


    void ShowObjError()
    {
        Msgbox.enabled = true;
        ShowMsgErrorText.enabled = true;
        CancelBtn.gameObject.SetActive(true);
        ShowMsgErrorText.text = "Plase select Gender";
        Gender.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);

    }


    void MoveToScenea()
    {

        Msgbox.enabled = true;
        Gender.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);

        for (int TimerMovScen = 0; TimerMovScen <=15; TimerMovScen++)
        {


            if (IsMale.isOn)
            {
                low_boy.gameObject.SetActive(true);
                low_Gail.gameObject.SetActive(false);


            }
            else if (IsFemale)
            {
                low_boy.gameObject.SetActive(false);
                low_Gail.gameObject.SetActive(true);

            }

            SceneManager.LoadScene("Game");
        }
    }


    public void SoundOn()
    {
        AudioScript.Instance.ToggleMuteSound();
    }



}