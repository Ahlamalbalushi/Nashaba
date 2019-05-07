using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BezierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] routes;

    private int routeToGo;
    private float Tparam;
    private Vector2 Shooterposition;
    private float SpeedModifier;
    private bool coroutineAllowed;
    



    // Start is called before the first frame update
    void Start()
    {

        routeToGo = 0;
        Tparam = 0f;
        SpeedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }



        private IEnumerator GoByTheRoute(int routeNumber)
    {

        coroutineAllowed = false;
        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;


        while (Tparam < 1)
        {
          
            Tparam += Time.deltaTime * SpeedModifier;

            Shooterposition = Mathf.Pow(1 - Tparam, 3) * p0 +
               3 * Mathf.Pow(1 - Tparam, 2) * Tparam * p1 +
                3 * (1 - Tparam) * Mathf.Pow(Tparam, 2) * p2 +
                Mathf.Pow(Tparam, 3) * p3;

            transform.position = Shooterposition;
            SceneManager.LoadScene("Menu");

          
                transform.Rotate(new Vector3(0, 0, 1f));




            yield return new WaitForEndOfFrame();



        }

        Tparam = 0f;
        routeToGo += 1;
        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;

        }
        coroutineAllowed = true;

       




    }
}
