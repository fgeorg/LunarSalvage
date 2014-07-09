using UnityEngine;

public class MouseFollower : MonoBehaviour {
	private Vector3 mousePosition;

	// Use this for initialization
	void Start () {
	}
	
	void FixedUpdate () {
		if (Input.GetMouseButton(0)) {
			mousePosition = Input.mousePosition;
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			Vector3 relativePosition = mousePosition - transform.position;
			Vector3 force = new Vector3(relativePosition.x, relativePosition.y, 0);
			if (force.sqrMagnitude > 0)
			{
				force.Normalize();
				force *= 40;
				rigidbody2D.AddForce(force);
			}
//			print(mousePosition + " " + force);


//			transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
		}
	}

	// Prints number of fingers touching the screen
	void Update () {
		var fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
		}
		if (fingerCount > 0)
			print ("User has " + fingerCount + " finger(s) touching the screen");
	}
}
