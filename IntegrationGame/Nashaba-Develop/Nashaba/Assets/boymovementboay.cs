using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boymovementboay : MonoBehaviour
{
    public GameObject L_EyeBrow;
    public GameObject R_EyeBrow;
    public GameObject mouth;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        L_EyeBrow.transform.position = new Vector2(transform.position.x-0.0f, transform.position.y);
      //  R_EyeBrow.transform.position = new Vector2(transform.position.x, transform.position.y);
        //mouth.transform.position = new Vector2(transform.position.x, transform.position.y);

    }
}
