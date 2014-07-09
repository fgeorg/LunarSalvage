using UnityEngine;
using System.Collections;

public class CameraPanning : MonoBehaviour {
	[SerializeField] private GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		camera.transform.position = new Vector3(player.transform.position.x,
		                                        player.transform.position.y,
		                                        camera.transform.position.z);

	}
}
