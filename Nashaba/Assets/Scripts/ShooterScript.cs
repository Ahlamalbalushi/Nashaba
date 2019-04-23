using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ShooterScript : MonoBehaviour
{

    public Action clicked;

    private void OnMouseDown()
    {
        clicked.Invoke();

        print("button down");
    }
        public void shot()
        {

            Invoke("ShooterDestroyed", 3);

        }

        void ShooterDestroyed()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Target")
            {
                print("Colid");


            }
        }
    }
