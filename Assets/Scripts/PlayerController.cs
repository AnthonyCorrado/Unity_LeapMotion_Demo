using UnityEngine;
using System.Collections;
using Leap;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundry boundry;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	private HandModel handModel;

	void Start ()
	{
		handModel = GetComponent<HandModel>();
		Controller controller = new Controller ();
		// wait until Controller.isConnected() evaluates to true
		//...
		
		Frame frame = controller.Frame ();
		HandList hands = frame.Hands;
		PointableList pointables = frame.Pointables;
		FingerList fingers = frame.Fingers;
		ToolList tools = frame.Tools;

		controller.EnableGesture (Gesture.GestureType.TYPE_SCREEN_TAP);
	}

	void Update ()
	{
		// Debug.Log();
		// Hand hand = GetComponent<HandModel>().GetLeapHand();

		if (Input.GetButton ("Fire1") && Time.time > nextFire)
		{
			nextFire =  Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		// float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;

		GetComponent<Rigidbody>().position = new Vector3 
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundry.xMin, boundry.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundry.zMin, boundry.zMax)
			);
	}
}
