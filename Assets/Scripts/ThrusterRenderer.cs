using UnityEngine;
using System.Collections;

public class ThrusterRenderer : MonoBehaviour {
	public float thrust;
	public SpriteRenderer fireSprite;
	public ParticleSystem particles;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (thrust > 0)
		{
			particles.Emit(5);
		}
		fireSprite.renderer.enabled = thrust > 0;
	}
}
