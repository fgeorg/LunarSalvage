using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {


	public AudioSource currentClip;
	public AudioSource nextClip;

	public GameInfo gameinfo;

	private AudioSource[] audioList; 

	public float timer;
	public float nextClipTime;

	private bool stayInLoop = false;

	// Use this for initialization
	void Start () {

		//au_background = this.gameObject.GetComponent("AudioSource");
		currentClip.loop = true;
		currentClip.Play();

		audioList = this.gameObject.GetComponents<AudioSource>();
		nextClipTime = (float)currentClip.clip.length;

		checkNextClip();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(stayInLoop == true) return;

		timer += Time.deltaTime;
	
		if(timer >= nextClipTime)
		{
			Debug.Log("Next Clip Playing!");

			currentClip.Stop ();
			currentClip = nextClip;
			currentClip.Play ();
			
			checkNextClip();

			timer = 0;
		}
	
	
	}

	private void checkNextClip()
	{
		
		switch (currentClip.clip.name) {
		case "intro-loop":
			
			
			foreach (AudioSource item in audioList) {
				if (item.clip.name == "transition") {
					
					nextClip = item;
				}
				
			}
			
			break;
			
		case "transition":
			
			foreach (AudioSource item in audioList) {
				if (item.clip.name == "main-loop") {
					
					nextClip = item;
	 
				}
				
			}
			
			
			break;
			
		case "main-loop":
			
			stayInLoop = true;

			break;
		}

	}
}
