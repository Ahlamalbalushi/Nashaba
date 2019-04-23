using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisplaySoundTest : MonoBehaviour
{
    public static PlayerDisplaySoundTest Instance;

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

    }

    // Update is called once per frame
    void Update()
    {
        print("Hit Sound");
        AudioScript.Instance.PlaySound("Hit");

    }
}
