using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	[SerializeField]
	private Vector3 spawnValues;

	[SerializeField]
	public GameObject generatedObject;

	public void SpawnFunction (int spawnQuantity, float spawnRotationX, float spawnRotationY, float spawnRotationZ) {
		for (int i = 0; i < spawnQuantity; i++) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				Random.Range (-spawnValues.y, spawnValues.y) + 20, Random.Range (-spawnValues.z, spawnValues.z));
			Quaternion spawnRotation = Quaternion.Euler(spawnRotationX, spawnRotationY, spawnRotationZ);

			Instantiate (generatedObject, spawnPosition, spawnRotation);
			spawnRotationY += 360.0f / spawnQuantity;
		}

	}
}
