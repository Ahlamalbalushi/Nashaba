using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform TextIndicator;

    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float Speed=10f;




    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += Speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
        }
        else
        {

            TextIndicator.GetComponent<Text>().text = "Done!";

           for(int i=0;i<5;i++)
            {
                SceneManager.LoadScene("Menu");
            }

        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }

}
