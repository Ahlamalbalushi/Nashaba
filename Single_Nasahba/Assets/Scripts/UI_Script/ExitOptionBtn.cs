using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitOptionBtn : MonoBehaviour
{

    //  public Toggle ExitOptionbtn;
    //  public GameObject BackLeveBtn;
    //  public GameObject HomeBtn;
    // public GameObject ExitBtn;
    public Toggle ExitOptionbtn;
    public GameObject AllOption;
    public GameObject SmsEndGame;

    private void Start()
    {

       // ExitOptionbtn.onValueChanged.AddListener(clickExitOption);
        ExitOptionbtn.onValueChanged.AddListener(delegate { ToggleValueChanged(ExitOptionbtn);});
    }



    void ToggleValueChanged(Toggle change)
    {

        if (ExitOptionbtn.isOn)
        {
            AllOption.SetActive(true);
            SmsEndGame.SetActive(false);
        }
        else
        {
            AllOption.SetActive(false);
           
        }

    }



}
