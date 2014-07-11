using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour
{
	private const float HEIGHT_TO_PICKUP = 5f;
	private GameObject magnet;
	public Vector3 InitialPosition;
	public bool ObjectIsPickedUp;

	void Start () {
		magnet = GameObject.FindGameObjectWithTag ("Magnet");
		InitialPosition = this.transform.position;
		ResetObject();
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
		if (transform.position.y > InitialPosition.y + HEIGHT_TO_PICKUP)
		{
			ObjectIsPickedUp = true;
		}
	}

	public void ResetObject()
	{
		ObjectIsPickedUp = false;
	}
}
