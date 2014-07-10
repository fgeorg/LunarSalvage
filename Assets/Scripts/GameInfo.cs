using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

	[SerializeField] public int gameStatus = 0; //0 Paused,1 Running,2 Won, 3 Lost
	[SerializeField] public int nJunkCollected = 0;

	// Use this for initialization
	void Start () 
	{
		gameStatus = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
