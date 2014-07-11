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
			GUI.Label(new Rect(screenWidth*0.5f - 450/2 ,screenHeight*0.1f,450,90), "Paused");
			if(GUI.Button(new Rect(screenWidth*0.5f - 400/2 ,screenHeight*0.15f,400,100), "Resume")) {
				gameInfo.gameStatus = 1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(screenWidth*0.5f - 200,screenHeight*0.25f,400,100), "Restart")) {
				Application.LoadLevel("MainMenu");
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
			GUI.Label(new Rect(screenWidth*0.5f - 150,screenHeight*0.1f,300,90), "You Won!");

			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.15f,200,100), "Again!")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.25f,200,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		case 3: // lost
			GUI.Label(new Rect(screenWidth*0.5f - 150,screenHeight*0.1f,300,90), "GAME OVER");

			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.15f,200,100), "Retry")) {
				Application.LoadLevel(gameInfo.currentLevel);
			}
			
			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.25f,200,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		case 4: // started
			GUI.Label(new Rect(screenWidth*0.5f - 150,screenHeight*0.1f,300,90), ""+gameInfo.currentLevel);
			
			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.15f,200,100), "Start")) {
				gameInfo.gameStatus=1;
				Time.timeScale = 1;
			}
			
			if(GUI.Button(new Rect(screenWidth*0.5f - 100,screenHeight*0.25f,200,100), "Quit")) {
				Application.LoadLevel("MainMenu");
			}
			break;

		}
	}
}
