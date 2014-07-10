using UnityEngine;

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
			particles.startColor = Color.Lerp(Color.yellow, Color.red, Random.value);
			particles.Emit(3);
		}
		fireSprite.renderer.enabled = thrust > 0;
	}
}
