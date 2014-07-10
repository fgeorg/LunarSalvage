using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {
	
	public GameInfo gameInfo;
	public GameObject explosionPrefab;
	public InputParser inputParser;
	public ThrusterRenderer leftThruster;
	public ThrusterRenderer rightThruster;

	public bool inSaveZone = true;
	void OnStart()
	{
		
	}
	
	void FixedUpdate() {
		if (inputParser.leftThrust > 0)
		{
			rigidbody2D.AddForceAtPosition (leftThruster.transform.rotation * new Vector2 (0, 2), leftThruster.transform.position);
			rigidbody2D.AddForce (transform.rotation * new Vector2 (0, 10));
			rigidbody2D.AddForce (new Vector2 (0, 4));
		}
		if (inputParser.rightThrust > 0)
		{
			rigidbody2D.AddForceAtPosition (rightThruster.transform.rotation * new Vector2 (0, 2), rightThruster.transform.position);
			rigidbody2D.AddForce (transform.rotation * new Vector2 (0, 10));
			rigidbody2D.AddForce (new Vector2 (0, 4));
		}
		leftThruster.thrust = inputParser.leftThrust;
		rightThruster.thrust = inputParser.rightThrust;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.name == "LandingZone" && inSaveZone != true) 
		{
			Debug.Log("Entered SaveZone");
			inSaveZone = true; 
			return;
		} 

		
	}

	void OnTriggerExit2D (Collider2D other) {
		
		if (other.gameObject.name == "StartZone" || other.gameObject.name == "LandingZone"  && inSaveZone != false) 
		{ 
			Debug.Log("Exited SaveZone");
			inSaveZone = false; 
			return;
		} 
		
	}


	void OnCollisionEnter2D (Collision2D other)
	{

		if (inSaveZone == true) return;

		gameInfo.gameStatus = 3;	
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}



}
