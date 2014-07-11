using UnityEngine;
using System.Collections;

public class CameraPanning : MonoBehaviour {
	[SerializeField] private GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player == null) return;
		Vector2 curPos = new Vector2(camera.transform.position.x, camera.transform.position.y);
		Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y - 3);
		Vector2 diff = playerPos - curPos;
		if (diff.sqrMagnitude > 0) {
			Vector2 toMove = diff * .02f;
			camera.transform.position = new Vector3(curPos.x + toMove.x,
			                                        curPos.y + toMove.y,
			                                        camera.transform.position.z);
//			float targetSize = 40 + (3.5f * player.rigidbody2D.velocity.magnitude);
//			camera.orthographicSize = camera.orthographicSize * .99f + targetSize * .01f;
		}



	}
}
