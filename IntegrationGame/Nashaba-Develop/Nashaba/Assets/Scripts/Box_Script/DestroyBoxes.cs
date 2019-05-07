using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxes : MonoBehaviour
{
    public static DestroyBoxes Instance;

    public float lifeTime = 5f;


    //private void Awake()
    //{
    //    //if (Instance == null)
    //    Instance = this;
    //    //else
    //    //    Destroy(this);
    //    //DontDestroyOnLoad(gameObject);
    //}

    // Update is called once per frame
    void Update()
    {

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Distruction();
        }
        if (this.transform.position.y <= -20)
        {
            Distruction();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            print("my Destroy");
            Distruction();
        }
    }

    void Distruction()
    {
        Destroy(gameObject);
    }
}
