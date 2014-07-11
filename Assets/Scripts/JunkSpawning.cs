using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class JunkSpawning : MonoBehaviour
{
	private const float distance = 9;
	public GameObject SpawningPlatform;
	// Use this for initialization
	void Start ()
	{
		SpawningPlatform.SetActive(false);
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool IsPlatformFree(Magnetic[] junks)
	{
		foreach (var junk in junks)
		{
			var dist = this.transform.position - junk.transform.position;
			if (dist.sqrMagnitude < distance)
			{
				return false;
			}
		}
		return true;
	}

}
