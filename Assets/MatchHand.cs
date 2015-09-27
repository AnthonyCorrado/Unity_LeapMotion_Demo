using UnityEngine;
using System.Collections;
using Leap;

public class MatchHand : MonoBehaviour {
	
	//Assume a reference to the scene HandController object
	public HandController handCtrl;
	
	void Update(){
		Frame frame = handCtrl.GetFrame();
		Hand hand = frame.Hands.Frontmost;
		if(hand.IsValid) {
			transform.position = 
				handCtrl.transform.TransformPoint(hand.PalmPosition.ToUnityScaled());
			transform.rotation = 
				handCtrl.transform.rotation * hand.Basis.Rotation(false);
		}
	}
}
