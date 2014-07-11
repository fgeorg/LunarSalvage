using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour
{
	private const float MIN_SIZE_JUNK = 0.6f;
	private const float MAX_SIZE_JUNK = 1.8f;
	private const float MIN_MASS_JUNK = 0.3f;
	private const float MAX_MASS_JUNK = 1f;
	private GameObject magnet;
	private float _size;
	public float Size
	{
		get { return _size; }
		set
		{
			_size = value;
			AdjustBoxToSize();
		}
	}

	private void AdjustBoxToSize()
	{
		var size = Mathf.Lerp(MIN_SIZE_JUNK, MAX_SIZE_JUNK, _size);
		this.gameObject.transform.localScale = new Vector3(size, size, size);
		var rigidBody = this.GetComponent<Rigidbody2D>();
		rigidBody.mass = Mathf.Lerp(MIN_MASS_JUNK, MAX_MASS_JUNK, _size);
	}

	void Start () {
		magnet = GameObject.FindGameObjectWithTag ("Magnet");
	}
	
	void FixedUpdate () {
		Vector2 pos = new Vector2(transform.position.x, transform.position.y);
		Vector2 magnetPos = new Vector2(magnet.transform.position.x, magnet.transform.position.y);
		Vector2 diff = magnetPos - pos;
		// force is relative to the inverse square of the distance
		if (diff.sqrMagnitude > 0)
		{
			float magnitude = diff.magnitude;
			magnitude = Mathf.Pow(magnitude, 3);
			magnitude = 5000.0f * 1.0f / (magnitude);
			Vector2 force = diff.normalized * magnitude;
			rigidbody2D.AddForce(force);
			magnet.rigidbody2D.AddForce(-force);
		}
	}
}
