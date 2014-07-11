using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	[SerializeField] public GUISkin menuSkin;

	private float screenWidth;
	private float screenHeight;

	// Use this for initialization
	void Start () 
	{
		screenHeight = (float)Screen.currentResolution.height;
		screenWidth = (float)Screen.currentResolution.width;
	}


	void FixedUpdate () {
	}


	void OnGUI () 
	{
		GUI.skin = menuSkin;

		GUI.Label(new Rect(screenWidth*0.5f,screenHeight*0.1f,screenWidth,screenHeight), "Welcome to Lunar Scrap yard!");

		if(GUI.Button(new Rect(screenWidth*0.5f,screenHeight*0.5f,200,200), "PLAY")) {
			Application.LoadLevel("Level");
		}

		GUI.Box(new Rect(screenWidth*0.5f,screenHeight*0.8f,1000,100), "Collect Scrap to earn points!");

		}
	}
