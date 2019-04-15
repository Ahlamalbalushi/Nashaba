using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using UnityEngine;
using GoogleARCore.Examples.Common;
using System;

public class PlayerScript : MonoBehaviour
{
    public GameObject Player;
    public Transform FirstPersonCamera;

    public Transform InitPosition;
  
    //public GameObject rubber;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
   void Update()
    {
      
        
          
      
        
    }

   public void setPlayer()
    {
        gameObject.SetActive(true);
        InstPlayer();
    }

    public void InstPlayer()
    {
        Instantiate(Player, InitPosition.position, transform.rotation,transform);
    }

    
}
