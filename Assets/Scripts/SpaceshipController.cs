using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {

	public GameInfo gameInfo;
	public GameObject explosionPrefab;
	public InputParser inputParser;
	public ThrusterRenderer leftThruster;
	public ThrusterRenderer rightThruster;

	void OnStart()
	{
		
	}

	void FixedUpdate() {
		Vector3 force = new Vector3();
		if (inputParser.leftThrust > 0)
		{
			force += new Vector3(10, 20, 0);
		}
		if (inputParser.rightThrust > 0)
		{
			force += new Vector3(-10, 20, 0);
		}
		rigidbody2D.AddForce(force);
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		gameInfo.gameStatus = 3;	
		Instantiate(explosionPrefab, transform.position, transform.rotation);
		Destroy (gameObject);
	}

}
