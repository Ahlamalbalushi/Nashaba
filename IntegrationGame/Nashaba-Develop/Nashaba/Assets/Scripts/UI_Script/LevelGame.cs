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

    public int ISactive = 0;


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
    }

    // Update is called once per frame
    void CreateObjes()
    {

        if (Levels.Instance.LevelNumber == 1)
        {
            Instantiate(box1, transform.position, transform.rotation);
            ISactive = 1;
           
            if (ISactive == 1)
            { 
            SceneManager.LoadScene("Levels");
            }

        }

       
         if (Levels.Instance.LevelNumber == 2)
        {
            Instantiate(box2, transform.position, transform.rotation);

            ISactive = 2;

            if (ISactive == 2)
            {
                SceneManager.LoadScene("Levels");
            }

        }
        

        if (Levels.Instance.LevelNumber == 3)
        {
            Instantiate(box3, transform.position, transform.rotation);
            ISactive = 3;

            if (ISactive == 3)
            {
                SceneManager.LoadScene("Levels");
            }
        }

    }
}
