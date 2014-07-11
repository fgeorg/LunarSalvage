using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {
	public Vector2 parallaxFactor;
	public Ferr2DT_PathTerrain terrain;
//	private Ferr2D_Path path;
	private Vector2 startPos;
	private Vector2 startCamPos;
	private GameObject mainCamera;
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		startCamPos = new Vector2 (mainCamera.transform.position.x, mainCamera.transform.position.y);
		startPos = new Vector2 (transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 camPosition = new Vector2 (mainCamera.transform.position.x, mainCamera.transform.position.y);
		Vector2 diff = camPosition - startCamPos;
		transform.position = new Vector3 (startPos.x + parallaxFactor.x * diff.x, startPos.y + parallaxFactor.y * diff.y, transform.position.z);
		terrain.RecreatePath ();
	}
}
