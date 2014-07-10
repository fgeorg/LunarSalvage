using UnityEngine;
using System.Collections;

public class ThrusterRenderer : MonoBehaviour {
	public float thrust;
	public SpriteRenderer fireSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		fireSprite.renderer.enabled = thrust > 0;
	}
}
