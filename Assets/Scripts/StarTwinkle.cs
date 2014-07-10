using UnityEngine;
using System.Collections;

public class StarTwinkle : MonoBehaviour {
	public SpriteRenderer sprite;
	private float offset;
	private float speed;
	// Use this for initialization
	void Start () {
		offset = Random.Range (0, Mathf.PI);
		speed = Random.Range (1.5f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float alpha = .5f + Mathf.Sin (offset + Time.time * Mathf.PI/speed) * .5f;
		sprite.color = new Color (sprite.color.r, sprite.color.g, sprite.color.b, alpha); 
	}
}
