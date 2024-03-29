﻿using UnityEngine;

public class InputParser : MonoBehaviour {
	public float leftThrust;
	public float rightThrust;
	private bool leftThrustOn;
	private bool rightThrustOn;
	private bool useTouch = false;
	// Use this for initialization
	void Start () {
	}
	
	void Update () {
		if (useTouch)
		{
			leftThrustOn = false;
			rightThrustOn = false;
		}

		foreach (Touch touch in Input.touches) {
			useTouch = true;
			if (touch.position.x > Screen.currentResolution.width / 2)
			{
				rightThrustOn = true;
			}
			else
			{
				leftThrustOn = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.A))
		{
			useTouch = false;
			leftThrustOn = true;
		}
		if (Input.GetKeyUp (KeyCode.A))
		{
			leftThrustOn = false;
		}
		if (Input.GetKeyDown (KeyCode.D))
		{
			useTouch = false;
			rightThrustOn = true;
		}
		if (Input.GetKeyUp (KeyCode.D))
		{
			rightThrustOn = false;
		}
	}

	void FixedUpdate () {
		if (rightThrustOn)
		{
			rightThrust += .02f;
			rightThrust = Mathf.Clamp01(rightThrust);
		}
		else
		{
			rightThrust = 0;
		}
		if (leftThrustOn)
		{
			leftThrust += .02f;
			leftThrust = Mathf.Clamp01(leftThrust);
		}
		else
		{
			leftThrust = 0;
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
