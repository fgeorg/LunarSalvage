using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour {
	private GameObject magnet;
	void Start () {
		magnet = GameObject.FindGameObjectWithTag ("Magnet");
	}
	
	void FixedUpdate () {
		Vector2 pos = new Vector2(transform.position.x, transform.position.y);
		Vector2 magnetPos = new Vector2(magnet.transform.position.x, magnet.transform.position.y);
		Vector2 diff = magnetPos - pos;
		// force is relative to the inverse square of the distance
		if (diff.sqrMagnitude > 0)
		{
			float magnitude = 200.0f * 1.0f / (diff.sqrMagnitude);
			Vector2 force = diff.normalized * magnitude;
			rigidbody2D.AddForce(force);
			magnet.rigidbody2D.AddForce(-force);
		}
	}
}
