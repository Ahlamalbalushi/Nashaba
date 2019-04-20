using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour 
{
	public GameObject BallPrefb;
	private GameObject ball;
	private bool isPressed, isBallThrown;
	private float power = 1;
	private Vector3 oldMousePos;
	public float myTimer = 2;
	public bool destroy;
	public GameObject dott;
	public GameObject dot;
	public static float velocity;
	//---------------------------------------	
	void Start ()
	{
		isPressed = isBallThrown =false;
	}
	//---------------------------------------	
	void Update () 
	{
		if (GameObject.Find("trajectory") != null) {
		dott = GameObject.Find("trajectory");}
		if (destroy==true){
			if(myTimer > 0){
				myTimer -= Time.deltaTime;
				}
			if(myTimer <= 0){
				destroy = false;
				Destroy (ball);
				Destroy (gameObject);
			}
		}
		if(!ball)
		createBall();
		if(isBallThrown)
			return;
		if(Input.GetMouseButtonDown(0))
		{ dot.SetActive(true);
			oldMousePos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
			isPressed = true;

		}
		else if(Input.GetMouseButtonUp(0))
		{
			isPressed = false;
			if(!isBallThrown)
			{ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				throwBall();
				destroy = true;
				Destroy (dott);

		}
		}
		if(isPressed)
		{
			Vector3 vel = GetForceFrom(oldMousePos,Camera.main.ScreenToWorldPoint(Input.mousePosition));
			float angle = Mathf.Atan2(vel.y*-1,vel.x*-1)* Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0,0,angle);
			setTrajectoryPoints(transform.position, vel/ball.GetComponent<Rigidbody>().mass);
		}
			}
	//---------------------------------------	
	// When ball is thrown, it will create new ball
	//---------------------------------------	
	private void createBall()
	{
		ball = (GameObject) Instantiate(BallPrefb);
		ball.name = "ball";
		Vector3 pos = transform.position;
		pos.z=5;
		ball.transform.position = pos;
		ball.SetActive(true);
	}
	//---------------------------------------	
	private void throwBall()
	{
		ball.SetActive(true);	
		ball.GetComponent<Rigidbody>().useGravity = true;
		ball.GetComponent<Rigidbody>().AddForce(GetForceFrom(oldMousePos,Camera.main.ScreenToWorldPoint(Input.mousePosition))*-1,ForceMode.Impulse);
		isBallThrown = true;

	}
	//---------------------------------------	
	private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
	{
		return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y))*power;//*ball.rigidbody.mass;
	}
	//---------------------------------------	
	// It displays projectile trajectory path
	//---------------------------------------	
	void setTrajectoryPoints(Vector3 pStartPosition , Vector3 pVelocity )
	{
		velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));

	}
}
//http://www.theappguruz.com/tutorial/display-projectile-trajectory-path-in-unity/