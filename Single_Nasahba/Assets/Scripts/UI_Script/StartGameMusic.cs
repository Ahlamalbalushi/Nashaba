using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMusic : MonoBehaviour
{

    private static StartGameMusic instance = null;
    public static StartGameMusic Instance { get { return Instance; } }

    //AudioSource myAudio;

    void Start()
    {
       // myAudio = GetComponent<AudioSource>();

    }



     void Awake()
    {
        if(instance!=null&& instance!=this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        { 

            DontDestroyOnLoad(this.gameObject);

        }


  //      myAudio.loop = true;
//        myAudio.Play();
    }

   


}
