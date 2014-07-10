using UnityEngine;
using System.Collections;

public class CableRenderer : MonoBehaviour {
	public DistanceJoint2D joint;
	public LineRenderer lineRenderer;
	public GameObject spaceShip;
	public GameObject magnet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 from = spaceShip.transform.position + spaceShip.transform.TransformVector (joint.anchor + new Vector2 (0, 1));
		Vector3 to = magnet.transform.position + magnet.transform.TransformVector (joint.connectedAnchor + new Vector2 (0, -1));
		float dst = (to - from).magnitude;
		float size = 1.0f - dst * 0.05f;
		lineRenderer.SetWidth (size, size);
		lineRenderer.SetPosition(0, from);
		lineRenderer.SetPosition(1, to);
	}
}
