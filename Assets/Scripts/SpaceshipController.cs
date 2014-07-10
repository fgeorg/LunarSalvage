using UnityEngine;
using System.Collections;

public class SpaceshipController : MonoBehaviour {

	[SerializeField] public GameInfo gameInfo;
	[SerializeField] public GameObject explosionPrefab;
	void OnStart()
	{
		
	}
	
	void OnCollisionEnter2D (Collision2D other)
	{
		gameInfo.gameStatus = 3;	
//		ParticleSystem ps = GetComponent<ParticleSystem>();
//		ps.Play ();
		Instantiate(explosionPrefab, transform.position, transform.rotation);
//		explosion.transform.position = gameObject.transform.position;
		Destroy (gameObject);
	}

}
