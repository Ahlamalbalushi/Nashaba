using GoogleARCore.Examples.CloudAnchors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
    public Text FirstscoreTxt;
    public Text SecondscoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FirstscoreTxt.text = "Score" + LocalPlayerController.instance.PlayerOnescore;
        SecondscoreTxt.text = "Score" + LocalPlayerController.instance.PlayerTwocore;

    }
}
