using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideLevel : MonoBehaviour
{

    public GameObject HideLevel2;
    public GameObject HideLevel3;



    void Start()
    {


     if (LevelGame.Instance.ISactive == 0)
        {
            HideLevel2.SetActive(true);
            HideLevel3.SetActive(true);
        }
        if (LevelGame.Instance.ISactive == 1)
        {
            HideLevel2.SetActive(false);
            //HideLevel3.SetActive(true);
        }
        if (LevelGame.Instance.ISactive == 2)
        {
           // HideLevel2.SetActive(false);
            HideLevel3.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
