using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {

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
}
