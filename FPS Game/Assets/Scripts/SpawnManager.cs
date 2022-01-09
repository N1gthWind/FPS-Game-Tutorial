using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public static SpawnManager Instance;

	Spawnpoint[] spawnpoints;

	void Awake()
	{
		Instance = this;
		spawnpoints = GetComponentsInChildren<Spawnpoint>();
	}

	public Transform GetSpawnpoint(int index) {

		try{
			return spawnpoints[index].transform;
		}
		catch {
			Debug.LogError("Spawnpoints were incorrect");
		}
		return spawnpoints[0].transform;
			
	}
}
