using UnityEngine;
using System.Collections;

public class backgroundSound : MonoBehaviour {


	public AudioSource au_background ;

	// Use this for initialization
	void Start () {

		//au_background = this.gameObject.GetComponent("AudioSource");
		au_background.loop = true;
		au_background.Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
