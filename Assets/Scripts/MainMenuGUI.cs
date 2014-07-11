using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	[SerializeField] public GUISkin menuSkin;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
	}


	void OnGUI () 
	{
		GUI.skin = menuSkin;

		GUI.Label(new Rect(160,10,800,100), "Welcome to Lunar Scrap yard!");

		if(GUI.Button(new Rect(410,100,200,200), "PLAY")) {
			Application.LoadLevel("Level");
		}

		GUI.Box(new Rect(0,300,1000,100), "Collect Scrap to earn points!");

		}
	}
