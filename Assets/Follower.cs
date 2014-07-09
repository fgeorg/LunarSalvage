using UnityEngine;

public class Follower : MonoBehaviour {
	private Vector3 mousePosition;
	private float moveSpeed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		Debug.Log("mouse pos: " + Input.mousePosition.x + Input.mousePosition.y);
		transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);//Vector3.Lerp(transform.position, mousePosition, moveSpeed);
	}
}
