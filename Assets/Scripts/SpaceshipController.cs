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
			rigidbody2D.AddForceAtPosition (leftThruster.transform.rotation * new Vector2 (0, inputParser.leftThrust * 1.0f), leftThruster.transform.position);
			rigidbody2D.AddForce (transform.rotation * new Vector2 (0, inputParser.leftThrust * 25));
			rigidbody2D.AddForce (transform.rotation * new Vector2 (inputParser.leftThrust * 50.0f, 0));
//			rigidbody2D.AddForce (new Vector2 (0, 10.0f));

			//			rigidbody2D.AddForce (new Vector2 (0, 1));
			if (!gameObject.GetComponent<AudioSource>().isPlaying)
				gameObject.GetComponent<AudioSource>().Play();
		}
		if (inputParser.rightThrust > 0)
		{
			rigidbody2D.AddForceAtPosition (rightThruster.transform.rotation * new Vector2 (0, inputParser.rightThrust * 1.0f), rightThruster.transform.position);
			rigidbody2D.AddForce (transform.rotation * new Vector2 (0, inputParser.rightThrust * 25));
			rigidbody2D.AddForce (transform.rotation * new Vector2 (inputParser.rightThrust * -50.0f, 0));
//			rigidbody2D.AddForce (new Vector2 (0, 10.0f));

//			rigidbody2D.AddForce (new Vector2 (0, 1));
			
			if (!gameObject.GetComponent<AudioSource>().isPlaying)
				gameObject.GetComponent<AudioSource>().Play();
		}
		
		if(inputParser.leftThrust == 0 && inputParser.rightThrust == 0)
			gameObject.GetComponent<AudioSource>().Stop();
		
		leftThruster.thrust = inputParser.leftThrust;
		rightThruster.thrust = inputParser.rightThrust;

		gameInfo.verticalSpeed   = (int)gameObject.GetComponent<Rigidbody2D> ().velocity.y;
		gameInfo.horizontalSpeed = (int)gameObject.GetComponent<Rigidbody2D> ().velocity.x;


	}
	
	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.gameObject.name == "LandingZone") 
		{
			Debug.Log("Entered SaveZone");
			inSaveZone = true; 
		} 

		
	}

	void OnTriggerExit2D (Collider2D other) {
		
		if ((other.gameObject.name == "StartZone" || other.gameObject.name == "LandingZone")) 
		{ 
			Debug.Log("Exited SaveZone");
			inSaveZone = false; 
		} 
		
	}


	void OnCollisionEnter2D (Collision2D other)
	{
//		if (inSaveZone) return;
		if (other.gameObject.name == "Magnet") return;
//		var junk = other.gameObject.GetComponentsInChildren<Magnetic> ();
//		if (junk != null) return;
		gameInfo.gameStatus = 3;	
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}



}
