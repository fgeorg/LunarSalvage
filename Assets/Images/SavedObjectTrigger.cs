using UnityEngine;
using System.Collections;

public class SavedObjectTrigger : MonoBehaviour
{
	[SerializeField] public GameInfo gameInfo;

	void OnStart()
	{
	
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log("HIT!");

		if(other.gameObject.name == "Junk")
		{
			Destroy(other.gameObject);
			gameInfo.nJunkCollected++;
			if (gameInfo.nJunkCollected >= 3)
			{
				gameInfo.gameStatus = 2;	
			}
		}
	}

	void OnGUI () {
		// Make a background box

		if (gameInfo.gameStatus == 2) {
				
			GUI.Box(new Rect(10,10,100,90), "You Won!");

			if(GUI.Button(new Rect(20,40,80,20), "Restart")) {
				//Application.LoadLevel(1);
			}

			if(GUI.Button(new Rect(20,70,80,20), "Quit")) {
				//Application.LoadLevel(2);
			}
		}
	}
}
