using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingProgressBar : MonoBehaviour
{
    public Transform LoadingBar;
    public Transform TextIndicator;
    public Transform TextLoading;

    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float Speed;




    void Update()
    {
        if (currentAmount < 100)
        {
            currentAmount += Speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            TextLoading.gameObject.SetActive(true);
        }
        else
        {

            TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "Done!";

           for(int i=0;i<5;i++)
            {
                SceneManager.LoadScene("Menu");
            }

        }

        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

    }

}
