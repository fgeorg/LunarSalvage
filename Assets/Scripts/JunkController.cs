using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class JunkController : MonoBehaviour
{
	private const int MAX_AMOUNT_JUNK = 5;
	private Magnetic[] junks;
	private JunkSpawning[] spawners;
	public GameObject JunkPrefab;

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
			GameObject go = (GameObject)Instantiate(JunkPrefab, GetRandomSpawnerPosition(), transform.rotation);
			go.transform.parent = this.transform;
		}
	}

	private Vector3 GetRandomSpawnerPosition()
	{
		var index = Random.Range(0, spawners.Length);
		while (!spawners[index].IsPlatformFree(junks))
		{
			index = Random.Range(0, spawners.Length);
		}
		return spawners[index].transform.position;
	}
}
