using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreenControl : MonoBehaviour
{


    public GameObject loadingScreenObj;
    public Slider slider;

    AsyncOperation async;

    public Text TextIndicator;

    public GameObject boy;

         

    //   public void LoadScreenExample(){}



    IEnumerator LoadingScreen()
    {

        loadingScreenObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while(async.isDone==false)
        {
            slider.value = async.progress/0.9f;

            if(async.progress==0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;

                    TextIndicator.text = slider.value*100 + "%";


            }
            yield return null;

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScreen());

    }

    // Update is called once per frame
    void Update()
    {

    }
}
