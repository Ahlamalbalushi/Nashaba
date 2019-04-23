using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructioable : MonoBehaviour
{

    public GameObject destruction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Instantiate(destruction, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
