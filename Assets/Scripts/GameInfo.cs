using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	public int gameStatus = 0; //0 Paused,1 Running,2 Won, 3 Lost
	public int nJunkCollected = 0;
	public int score = 00000;

	public string currentLevel;
	public string nextLevel;

	public float minutes;
	public float seconds;

	public int horizontalSpeed;
	public int verticalSpeed;

	private float timer;


	// Use this for initialization
	void Start () 
	{
		gameStatus = 4;
		Time.timeScale = 1;
		currentLevel = Application.loadedLevelName;

	}
	
	// Update is called once per frame
	void Update () 
	{
		timer +=Time.deltaTime;

		 minutes = Mathf.Floor(timer / 60);
		 seconds = timer%60;
	}

	public void PointsCollectedFromJunk(float size)
	{
		var points = Mathf.Lerp(20, 80, size);
		var extraTime = Mathf.Lerp(5, 10, size);
		Debug.Log("collected points: " + points + " extraTime: " + extraTime);
	}
}
