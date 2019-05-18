using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SclaSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        transform.localScale += new Vector3(1f, 1f, 1f);   
    }
}
