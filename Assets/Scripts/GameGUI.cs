using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	[SerializeField] public GameInfo gameInfo;
	[SerializeField] public GUISkin lunarSkin;

	// Use this for initialization
	void Start () {
	}

	void FixedUpdate () {
	}


	void OnGUI () {
		GUI.skin = lunarSkin;

		switch (gameInfo.gameStatus) {
		case 0: // paused
			GUI.Box(new Rect(10,10,100,90), "Paused");
			if(GUI.Button(new Rect(20,40,80,20), "Resume")) {
				gameInfo.gameStatus = 1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Restart")) {
				Application.LoadLevel(gameInfo.currentLevel);
				Time.timeScale = 1;
			}
			break;
		case 1: // playing
			if(GUI.Button(new Rect(5,5,100,100), "Pause")) {
				gameInfo.gameStatus = 0;
				Time.timeScale = 0;
			}
			GUI.Label(new Rect(640,10,250,40), "Goal: Deliver 1 junk to win!");


			//HUD
			GUI.Label(new Rect(120,10,300,40), "Score: "+ gameInfo.score);

			if (gameInfo.minutes <= 0)
			{
				GUI.Label(new Rect(120,50,600,40), "Time: "+gameInfo.seconds);
				break;
			}
			else
			GUI.Label(new Rect(120,50,600,40), "Time: "+ gameInfo.minutes +":"+gameInfo.seconds);


			break;
		case 2: // won
			GUI.Label(new Rect(490,100,300,90), "You Won!");

			if(GUI.Button(new Rect(450,150,100,100), "Again!")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(550,150,100,100), "Next")) {
				//Application.LoadLevel(2);
			}
			break;

		case 3: // lost
			GUI.Label(new Rect(490,100,300,90), "You Lost!");

			if(GUI.Button(new Rect(450,150,100,100), "Retry")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(550,150,100,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		case 4: // started
			GUI.Label(new Rect(490,100,300,90), ""+gameInfo.currentLevel);
			
			if(GUI.Button(new Rect(450,150,100,100), "Start")) {
				gameInfo.gameStatus=1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(550,150,100,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		}
	}
}
