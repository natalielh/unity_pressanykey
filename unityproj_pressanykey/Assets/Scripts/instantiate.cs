using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour {

	public GameObject generatedObject;
	public GameObject generatedObject2;

	public Vector3 spawnValues;

	[SerializeField]
	private Spawn spawnBox;


	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			spawnBox.SpawnFunction (10, 0, 0, 0);

		}

		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 
				Random.Range (-spawnValues.y, spawnValues.y) + 10, Random.Range (-spawnValues.z, spawnValues.z));
			Quaternion spawnRotation = Quaternion.Euler(Random.Range(0.0f, 360.0f), 
				Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));

			Instantiate (generatedObject2, spawnPosition, spawnRotation);

		}
			
	}
}
