using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    public static AudioScript Instance;

    AudioSource myAudio;

    public AudioClip StartGame;
    public AudioClip EndGame;

    public AudioClip ClickBtn;
    public AudioClip smsalert;

    public AudioClip TimerTick;
    public AudioClip ShootingPlayer;
    public AudioClip DestoryBox1;
    public AudioClip DestoryBox2;
    public AudioClip DendgersTimer;

    public AudioClip EatingFood;
    public AudioClip Coins;
    public AudioClip CollectCoins;

    public AudioClip Heart;


    public GameObject SoundOff;
    public GameObject SoundOn;


    void Awake()

    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void PlaySound(string soundName)
    {
        switch (soundName)
        {
            case "StartGame":
                myAudio.clip = StartGame;
                break;

            case "EndGame":
                myAudio.clip = EndGame;
                break;

            case "ClickBtn":
                myAudio.clip = ClickBtn;
                break;

            case "smsalert":
                myAudio.clip = smsalert;
                break;

            case "TimerTick":
                myAudio.clip = TimerTick;
                break;

            case "ShootingPlayer":
                myAudio.clip = ShootingPlayer;
                break;

            case "DestoryBox1":
                myAudio.clip = DestoryBox1;
                break;

            case "DestoryBox2":
                myAudio.clip = DestoryBox2;
                break;

            case "DendgersTimer":
                myAudio.clip = DendgersTimer;
                break;

            case "EatingFood":
                myAudio.clip = EatingFood;
                break;


            case "Coins":
                myAudio.clip = Coins;
                break;

            case "CollectCoins":
                myAudio.clip = CollectCoins;
                break;


            case "Heart":
                myAudio.clip = Heart;
                break;
        }

        myAudio.Play();
    }


    public void ToggleMuteSound()
    {
        if (myAudio.volume == 1)
        {
            myAudio.volume = 0;
            SoundOff.SetActive(true);

            print("No Sound");

        }
        else if (myAudio.volume == 0)
        {
            myAudio.volume = 1;
            SoundOff.SetActive(false);


            print("Sound");
        }
    }


}