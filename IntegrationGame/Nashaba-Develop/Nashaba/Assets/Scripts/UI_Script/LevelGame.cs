using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelGame : MonoBehaviour
{


    public static LevelGame Instance;

    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public Button CreateObje;
    public Button GameExit;





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

        CreateObje.onClick.AddListener(CreateObjes);
        GameExit.onClick.AddListener(GameExitLevel);

    }


     void CreateObjes()
    {

        if (Levels.Instance.LevelNumber == 1)
        {
            Instantiate(box1, transform.position, transform.rotation);

        }

       else if (Levels.Instance.LevelNumber == 2)
        {
            Instantiate(box2, transform.position, transform.rotation);
        }


        else if (Levels.Instance.LevelNumber == 3)
        {
            Instantiate(box3, transform.position, transform.rotation);
        }




    }

   
    void GameExitLevel()
    {
       

        SceneManager.LoadScene("Levels");
      //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);

       //Application.LoadLevel(Application.loadedLevel);

    }





}



