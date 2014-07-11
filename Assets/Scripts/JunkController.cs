using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class JunkController : MonoBehaviour
{
	private const int MAX_AMOUNT_JUNK = 20;
	private Magnetic[] junks;
	private JunkSpawning[] spawners;
	public GameObject JunkPrefab1;
	public GameObject JunkPrefab2;
	public GameObject JunkPrefab3;

	// Use this for initialization
	void Start ()
	{
		junks = GetComponentsInChildren<Magnetic>();
		spawners = GetComponentsInChildren<JunkSpawning>();

	}
	
	void FixedUpdate () {
		junks = GetComponentsInChildren<Magnetic>();
		if (junks.Length < MAX_AMOUNT_JUNK)
		{
			GameObject go = (GameObject)Instantiate(GetJunkPrefab(), GetRandomSpawnerPosition(), transform.rotation);
			go.transform.parent = this.transform;
			var magnetic = go.GetComponentInChildren<Magnetic>();
			magnetic.Size = Random.value;
		}
	}

	private Vector3 GetRandomSpawnerPosition()
	{
		var index = Random.Range(0, spawners.Length);
		if (junks != null && junks.Length > 0)
		{
			while (!spawners[index].IsPlatformFree(junks))
			{
				index = Random.Range(0, spawners.Length);
			}
		}
		return spawners[index].transform.position;
	}

	private GameObject GetJunkPrefab()
	{
		int ind = Random.Range(0, 3);
		switch (ind)
		{
			case 0:
				return JunkPrefab1;
				break;
			case 1:
				return JunkPrefab2;
				break;
			case 2:
				return JunkPrefab3;
				break;
		}
		return JunkPrefab1;
	}
}
