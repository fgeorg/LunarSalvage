using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	[SerializeField] public GameInfo gameInfo;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
	}


	void OnGUI () {
		switch (gameInfo.gameStatus) {
		case 0: // paused
			GUI.Box(new Rect(10,10,100,90), "Paused");
			if(GUI.Button(new Rect(20,40,80,20), "Resume")) {
				gameInfo.gameStatus = 1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
			break;
		case 1: // playing
			if(GUI.Button(new Rect(20,40,80,20), "Pause")) {
				gameInfo.gameStatus = 0;
				Time.timeScale = 0;
			}
			GUI.Label(new Rect(10,10,300,20), "EVERYTHING IS AWESOME (collect it)");
			break;
		case 2: // won
			GUI.Box(new Rect(10,10,100,90), "You Won!");
			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
			break;

		case 3: // lost
			GUI.Box(new Rect(10,10,100,90), "You Lost!");
			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
				//Application.LoadLevel(1);
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
			break;

		}
	}
}
