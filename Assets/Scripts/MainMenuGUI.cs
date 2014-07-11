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

		GUI.Label(new Rect(0,screenHeight*0.05f,screenWidth,screenHeight), "Welcome to Lunar Scrap yard!");

		if(GUI.Button(new Rect(screenWidth*0.5f -200 ,screenHeight*0.5f -100,400,200), "PLAY")) {
			Application.LoadLevel("Level");
		}

		GUI.Box(new Rect(screenWidth/2 - (screenWidth * 0.3f)/2,screenHeight*0.15f,screenWidth * 0.3f,screenHeight * 0.1f), "Collect Scrap to earn points!!");



		}
	}
