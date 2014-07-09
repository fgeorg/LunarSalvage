using UnityEngine;
using System.Collections;

public class CameraPanning : MonoBehaviour {
	[SerializeField] private GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 curPos = new Vector2(camera.transform.position.x, camera.transform.position.y);
		Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y - 5);
		Vector2 diff = playerPos - curPos;
		if (diff.sqrMagnitude > 2.0f * 2.0f) {
			Vector2 toMove = diff * .01f;
			camera.transform.position = new Vector3(curPos.x + toMove.x,
			                                        curPos.y + toMove.y,
			                                        camera.transform.position.z);
			float targetSize = 12 + 2 * player.rigidbody2D.velocity.magnitude;
			camera.orthographicSize = camera.orthographicSize * .99f + targetSize * .01f;
		}



	}
}
