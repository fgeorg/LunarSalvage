using UnityEngine;
using System.Collections;

public class CableRenderer : MonoBehaviour {
	public CablePhysics cablePhysics;
	public LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 from = cablePhysics.body1.transform.position + cablePhysics.body1.transform.TransformVector (cablePhysics.body1Anchor + new Vector2 (0, 1));
		Vector3 to = cablePhysics.body2.transform.position + cablePhysics.body2.transform.TransformVector (cablePhysics.body2Anchor + new Vector2 (0, -1));
		float dst = (to - from).magnitude;
		float size = 1.0f - dst * 0.05f;
		lineRenderer.SetWidth (size, size);
		lineRenderer.SetPosition(0, from);
		lineRenderer.SetPosition(1, to);
	}
}
