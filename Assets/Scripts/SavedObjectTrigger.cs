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
		var junk = other.gameObject.GetComponentInChildren<Magnetic>();
		if (junk != null)
		{
			Destroy(other.gameObject);
			gameInfo.nJunkCollected++;
			gameInfo.PointsCollectedFromJunk(junk.Size);
			if (gameInfo.nJunkCollected >= 3)
			{
				gameInfo.gameStatus = 2;	
			}
		}
	}

}
