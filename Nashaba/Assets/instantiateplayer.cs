using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateplayer : MonoBehaviour
{

    public GameObject player;
    Quaternion ssss = Quaternion.identity;

    // Start is called before the first frame update
#pragma warning disable CS0618 // Type or member is obsolete
    void Start() => ssss.SetAxisAngle(new Vector3(2f, 0f, 0f), -100);
#pragma warning restore CS0618 // Type or member is obsolete

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        Instantiate(player, new Vector3(-0.65f, 3.45f, -9.95f), ssss);
    }
}
