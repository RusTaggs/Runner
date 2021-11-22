using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
	[SerializeField]
    private GameObject[] obstacles;
	[SerializeField]
	private float minSpawnRange = 1f;
	[SerializeField]
	private float maxSpawnRange = 2f;

	private bool spawned;

	private void Start()
	{
		StartCoroutine(Spawn());
	}

	private void Update()
	{
		if (spawned)
		{
			StartCoroutine(Spawn());
			spawned = false;
		}
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds(Random.Range(minSpawnRange, maxSpawnRange));
		Spawner();
	}

	private void Spawner()
	{
		Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform);
		spawned = true;
	}
}
