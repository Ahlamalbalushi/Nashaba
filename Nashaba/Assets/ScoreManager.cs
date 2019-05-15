using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618
public class ScoreManager : NetworkBehaviour

{
    public int Score;
    NetworkIdentity identity;
    public static ScoreManager Instance; 


    private void Start()
    {
        identity = GetComponent<NetworkIdentity>();

        Instance = this;
    }
    // Start is called before the first frame update

    public void Point(GameObject obj)
    {
        Score++;
        UiManger.Instance.UpdateMyScore(Score);
        //UiManger.Instance.Debug.text = "is local " + identity.isLocalPlayer + " netID " + identity.netId + " playerid " + identity.playerControllerId;

        CmdDestroyCube(obj, identity.netId.Value, Score);


    }

    [Command]
    public void CmdDestroyCube(GameObject obj, uint id, int otherScore)
    {

        NetworkServer.Destroy(obj);


        if (id != identity.playerControllerId)
        {
            UiManger.Instance.UpdateOtherScore(otherScore);
        }

        print("id " + id + " " + identity.netId);

    }
}
#pragma warning restore 618