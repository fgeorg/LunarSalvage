using UnityEngine;

public class InputParser : MonoBehaviour {
	public float leftThrust;
	public float rightThrust;

	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.A))
		{
			leftThrust = 1;
		}
		if (Input.GetKeyUp (KeyCode.A))
		{
			leftThrust = 0;
		}
		if (Input.GetKeyDown (KeyCode.D))
		{
			rightThrust = 1;
		}
		if (Input.GetKeyUp (KeyCode.D))
		{
			rightThrust = 0;
		}
	}

	// Prints number of fingers touching the screen
//	void Update () {
//		var fingerCount = 0;
//		foreach (Touch touch in Input.touches) {
//			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
//				fingerCount++;
//		}
//		if (fingerCount > 0)
//			print ("User has " + fingerCount + " finger(s) touching the screen");
//	}
}
