using UnityEngine;
using System.Collections;
using Leap;

public class Gestures : GestureDisplay {
	
	public Leap.Gesture gesture;
	public Frame frame;
	
	void Start () 
	{
		Controller controller = new Controller ();
		// wait until Controller.isConnected() evaluates to true
		//...
		
		Frame frame = controller.Frame ();
		HandList hands = frame.Hands;
		PointableList pointables = frame.Pointables;
		FingerList fingers = frame.Fingers;
		ToolList tools = frame.Tools;

	}

	void Update ()
	{
		Debug.Log(frame);
	}
}