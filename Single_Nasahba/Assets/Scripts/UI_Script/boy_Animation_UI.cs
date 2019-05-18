using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boy_Animation_UI : MonoBehaviour
{

    public GameObject FaceAnmiBoy1;
    public GameObject FaceAnmiBoy2;


    public bool ShowAnmi=true;
    public float timer = 2;

    public int moveScen =0;

    // Start is called before the first frame update
    void Start()
    {

        FaceAnmiBoy1.SetActive(true);
        FaceAnmiBoy2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {



        timer -= Time.deltaTime;



        if (ShowAnmi)
        {
            if (timer <= 0)
            {
                FaceAnmiBoy1.SetActive(true);
                FaceAnmiBoy2.SetActive(false);
                ShowAnmi = false;
                timer = 2;

            }
        }



        if (ShowAnmi == false)
        {
            if (timer <= 0)
            {
                FaceAnmiBoy1.SetActive(false);
                FaceAnmiBoy2.SetActive(true);
                ShowAnmi = true;
                timer = 2;
                moveScen++;
                print(moveScen);


                if (moveScen == 2)
                {
                    FaceAnmiBoy2.gameObject.transform.Rotate(2f, 2f, 2f);
                    // SceneManager.LoadScene("Menu");
                    StartCoroutine("Wait");
                }

            }



        }

    }

      

[System.Obsolete]
IEnumerator Wait()
{
    yield return new WaitForSeconds(1f);
      
            Application.LoadLevel("Menu");

       
}





}
