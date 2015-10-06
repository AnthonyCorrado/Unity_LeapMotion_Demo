using UnityEngine;
using System.Collections;
using Leap;

[System.Serializable]
public class Boundry
{
	public float xMin, xMax, zMin, zMax;
}


public class SpaceShip : MonoBehaviour {

	public float speed;
	public Boundry boundry;
	
	//Assume a reference to the scene HandController object
	public HandController handCtrl;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;
	
	void Update(){
		Frame frame = handCtrl.GetFrame();
		Hand rightHand = frame.Hands.Rightmost;
		HandList handsInFrame = frame.Hands;

		if(rightHand.IsValid)
		{
			transform.position = 
				handCtrl.transform.TransformPoint(rightHand.PalmPosition.ToUnityScaled());
			transform.rotation = 
				handCtrl.transform.rotation * rightHand.Basis.Rotation(false);
		}

		if (handsInFrame.Count > 1 && Time.time > nextFire)
		{
			nextFire =  Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}

//		if (Input.GetButton ("Fire1") && Time.time > nextFire)
//		{
//			nextFire =  Time.time + fireRate;
//			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
//		}

	}
	void FixedUpdate ()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		// float moveVertical = Input.GetAxis ("Vertical");
//		
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
//		GetComponent<Rigidbody>().velocity = movement * speed;
//		
//		GetComponent<Rigidbody>().position = new Vector3 
//			(
//				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundry.xMin, boundry.xMax),
//				0.0f,
//				Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundry.zMin, boundry.zMax)
//				);
	}
}
