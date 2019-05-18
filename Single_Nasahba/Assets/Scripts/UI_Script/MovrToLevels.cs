using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovrToLevels : MonoBehaviour
{
    public Button BackToLevelsBtn;

    // Start is called before the first frame update
    void Start()
    {
        BackToLevelsBtn.onClick.AddListener(BackToLevel);

    }


        void BackToLevel()
        {
            AudioScript.Instance.PlaySound("ClickBtn");
            SceneManager.LoadScene("Levels");
        }

}
