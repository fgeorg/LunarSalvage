using UnityEngine;
using System.Collections;

public class CrashTrigger : MonoBehaviour {

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
		Destroy (this);
	}
	
	void OnGUI () {
		// Make a background box
		
		if (gameInfo.gameStatus == 3) {
			
			GUI.Box(new Rect(10,10,100,90), "You Lost!");
			
			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
				//Application.LoadLevel(1);
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
		}
		
		
	}
}
