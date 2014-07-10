using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {
	public float parallaxFactor;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(8.0f, 8.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
		Vector3 targetPosition = camera.transform.position * (1 + parallaxFactor);
		transform.position = new Vector3 (targetPosition.x, targetPosition.y, transform.position.z);
	}
}
