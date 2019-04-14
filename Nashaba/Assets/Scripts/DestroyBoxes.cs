using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxes : MonoBehaviour
{
    public float lifeTime = 10f;

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Distruction();
            }
        }
        if (this.transform.position.y <= -20)
        {
            Distruction();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.name == "FirstTarget")
    //    {
    //        print("my Destroy");
    //        Distruction();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(other.gameObject);
            print("Touched");
        }
    }
    void Distruction()
    {
        Destroy(gameObject);
    }
}
