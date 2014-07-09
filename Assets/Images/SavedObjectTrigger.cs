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

}
