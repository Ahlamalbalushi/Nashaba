using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using GoogleARCore.Examples.CloudAnchors;

public class ShooterScript : MonoBehaviour
{
    public GameObject smoke;
    //bool doit = true;
    //public bool isDestroyed = false;

    public Action OnDestroyed;
    //public GameObject destroyedCube;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

    

    }

    public void shot()
    {

        Invoke("ShooterDestroyed", 3);

    }

    void ShooterDestroyed()
    {
        Destroy(gameObject);
        OnDestroyed.Invoke();
    }

    void destroythissmoke()
    {
        Destroy(this.gameObject);
    }


   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Instantiate(smoke, this.transform.position, Quaternion.identity);
            
        }
        if (collision.gameObject.tag == "cube")
        {

            // CmdDestroyButton(collision.gameObject);
            //gameObject.SetActive(false);
            // Destroy(collision.gameObject);
            //isDestroyed = true;
            //destroyedCube = collision.gameObject;

            //LocalPlayerController.Instance.RpcDestrroyCube(collision.gameObject.name);
            //DestrroyCube(collision.gameObject);



        }
    }

    //[Command]
    //public void CmdDestroyButton(GameObject obj)
    //{
    //    NetworkServer.Destroy(obj);
    //}


   


}
