using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundEffect : MonoBehaviour
{
    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {


    }


    void Awake()
    {

        myAudio.loop = false;
        myAudio.Play();
    }
}
