using GoogleARCore.Examples.CloudAnchors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
    public Text FirstscoreTxt;
    public Text secondScoreTxt;

    public Text Debug;

    public static UiManger Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMyScore(int Score)
    {
        FirstscoreTxt.text = "Score" + Score;
    }

    public void UpdateOtherScore(int Score)
    {
        secondScoreTxt.text = "score" + Score;
    }
}
