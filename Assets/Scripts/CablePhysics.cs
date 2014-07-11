using UnityEngine;
using System.Collections;

public class CablePhysics : MonoBehaviour {
	public Rigidbody2D body1;
	public Vector2 body1Anchor;
	public Rigidbody2D body2;
	public Vector2 body2Anchor;
	public float distance;
	public float strength;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 pos1 = body1.transform.position + body1.transform.TransformVector(body1Anchor);
		Vector2 pos2 = body2.transform.position + body2.transform.TransformVector(body2Anchor);
		Vector2 dir = pos2 - pos1;
//		Debug.Log (dir);
		float mag = dir.magnitude;
		if (mag == 0) return;
		dir.Normalize ();
		if (mag > distance) {
			float strength = .25f * (mag * mag - distance * distance);
			if (strength > 60) strength = 60; 
			body1.AddForceAtPosition(strength * dir, pos1);
			body2.AddForceAtPosition(strength * -dir, pos2);
		}
		else
		{
			body1.AddForceAtPosition((.4f + (distance - mag)) * -dir, pos1);
			body2.AddForceAtPosition((.4f + (distance - mag)) * dir, pos2);
		}
	}
}
