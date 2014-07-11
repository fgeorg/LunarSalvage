using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
	[SerializeField] public GameInfo gameInfo;
	[SerializeField] public GUISkin lunarSkin;

	private float screenWidth;
	private float screenHeight;

	// Use this for initialization
	void Start () {

		screenHeight = (float)Screen.currentResolution.height;
		screenWidth = (float)Screen.currentResolution.width;
	}

	void FixedUpdate () {
	}


	void OnGUI () {
		GUI.skin = lunarSkin;

		switch (gameInfo.gameStatus) {
		case 0: // paused
			GUI.Label(new Rect(screenWidth*0.525f,screenHeight*0.1f,300,90), "Paused");
			if(GUI.Button(new Rect(screenWidth*0.45f,screenHeight*0.15f,100,100), "Resume")) {
				gameInfo.gameStatus = 1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(screenWidth*0.55f,screenHeight*0.15f,100,100), "Restart")) {
				Application.LoadLevel(gameInfo.currentLevel);
				Time.timeScale = 1;
			}
			break;
		case 1: // playing
			if(GUI.Button(new Rect(5,5,100,100), "Pause")) 
			{
				gameInfo.gameStatus = 0;
				Time.timeScale = 0;
			}

			//HUD
			GUI.Label(new Rect(120,10,300,40), "Score: "+ gameInfo.score);
			GUI.Label(new Rect(320,10,600,40), "Horizontal Speed: "+ gameInfo.horizontalSpeed);
			GUI.Label(new Rect(320,50,600,40), "Vertical Speed: "+ gameInfo.verticalSpeed);


			if (gameInfo.minutes <= 0)
			{
				GUI.Label(new Rect(120,50,600,40), "Time: "+gameInfo.seconds);
				break;
			}
			else
			GUI.Label(new Rect(120,50,600,40), "Time: "+ gameInfo.minutes +":"+gameInfo.seconds);




			break;
		case 2: // won
			GUI.Label(new Rect(screenWidth*0.525f,screenHeight*0.1f,300,90), "You Won!");

			if(GUI.Button(new Rect(screenWidth*0.45f,screenHeight*0.15f,100,100), "Again!")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(screenWidth*0.55f,screenHeight*0.15f,100,100), "Next")) {
				//Application.LoadLevel(2);
			}
			break;

		case 3: // lost
			GUI.Label(new Rect(screenWidth*0.525f,screenHeight*0.1f,300,90), "You Lost!");

			if(GUI.Button(new Rect(screenWidth*0.45f,screenHeight*0.15f,100,100), "Retry")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(screenWidth*0.55f,screenHeight*0.15f,100,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		case 4: // started
			GUI.Label(new Rect(screenWidth*0.525f,screenHeight*0.1f,300,90), ""+gameInfo.currentLevel);
			
			if(GUI.Button(new Rect(screenWidth*0.45f,screenHeight*0.15f,100,100), "Start")) {
				gameInfo.gameStatus=1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(screenWidth*0.55f,screenHeight*0.15f,100,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		}
	}
}
