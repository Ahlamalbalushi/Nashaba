using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [System.Serializable]

    public class Level
    {
        public string LevelText;
        public int UnLocked;
        public bool IsIneractable;
        public Button.ButtonClickedEvent OnClickEvent;
    }

    public GameObject levelBtn;
    public Transform Spacer;


    public List<Level> LevelList;


    private void Start()
    {
        //DeleteAll();
        FillList();
    }


    void FillList()
    {
        foreach (var level in LevelList)
        {

            GameObject newbutton = Instantiate(levelBtn) as GameObject;
            LevelBtn button = newbutton.GetComponent<LevelBtn>();
            button.LevelText.text = level.LevelText;

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1)
            {
                level.UnLocked = 1;
                level.IsIneractable = true;
              
                
            }
            button.UnLocked = level.UnLocked;
            button.GetComponent<Button>().interactable = level.IsIneractable;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevels("Level" + button.LevelText.text));


            if(PlayerPrefs.GetInt("Level"+button.LevelText.text+"_Score")>0)
            {
                button.Start1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_Score") > 5000)
            {
                button.Start2.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_Score") > 9999)
            {
                button.Start3.SetActive(true);
            }

            newbutton.transform.SetParent(Spacer);
        }
        SaveAll();

    }


    void SaveAll()
    {

        GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelBtn");

        foreach (GameObject buttons in allButtons)
        {
            LevelBtn button = buttons.GetComponent<LevelBtn>();
            PlayerPrefs.SetInt("Level" + button.LevelText.text, button.UnLocked);
        }


    }


    /*

    void DeleteAll()

    {
        PlayerPrefs.DeleteAll();

    }*/



    void LoadLevels(string value)
    {
        Application.LoadLevel(value);

    }



}