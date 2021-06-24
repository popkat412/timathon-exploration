using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsGenerator : MonoBehaviour
{
	public int trapsSpawnRate = 10;
	public int trapsSpawnSquareWidth = 100;
	public GameObject spikesPrefab;
	void Start()
	{
		for (int i = 0; i < trapsSpawnRate; i++)
		{
			int randomX = Random.Range(-trapsSpawnSquareWidth, trapsSpawnSquareWidth), randomY = Random.Range(-trapsSpawnSquareWidth, trapsSpawnSquareWidth);
			GameObject instance = Instantiate(spikesPrefab, new Vector3(randomX, 0, randomY), Quaternion.identity);
			instance.transform.parent = transform;
		}

	}
}
