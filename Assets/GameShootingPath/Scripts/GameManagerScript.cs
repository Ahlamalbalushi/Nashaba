using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject spawnspot;
	void Start ()
	{
		initializeGamePlay();	
	}
	void initializeGamePlay()
	{  
		Vector3 position = new Vector3(Random.Range(-4.0F, 7.5F),Random.Range(-0.1F, 4.0F), 10);
		GameObject spawn = (GameObject) Instantiate(spawnspot, position, Quaternion.identity);
		spawn.name = "spawn";
		}

	void Update () 
	{
		if (GameObject.Find("spawn") == null) {
			initializeGamePlay();	
		}

		}
}
////http://www.theappguruz.com/tutorial/display-projectile-trajectory-path-in-unity/