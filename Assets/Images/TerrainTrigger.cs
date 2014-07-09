using UnityEngine;
using System.Collections;

public class TerrainTrigger : MonoBehaviour {

	[SerializeField] public GameInfo gameInfo;
	
	void OnStart()
	{
		
	}
	
	
	
	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log("HIT!");
		
		if(other.gameObject.name == "Magnet"|| other.gameObject.name == "Spaceship" )
		{
			
			gameInfo.gameStatus = 3;	
		}
	}
	
	void OnGUI () {
		// Make a background box
		
		if (gameInfo.gameStatus == 3) {
			
			GUI.Box(new Rect(10,10,100,90), "You Lost!");
			
			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
				//Application.LoadLevel(1);
			}
			
			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
		}
		
		
	}
}
