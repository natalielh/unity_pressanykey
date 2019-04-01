using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadialSpawn : MonoBehaviour {

	//see Spiral Spawn for Comment explainations

	public GameObject hazard1;
	public KeyCode userKey;


	public Vector3 spawnValues;
	public int waveLength;

	private float fCount;
	public float spawnWait;

	private float spawnRotationY;

	private bool press;

	public float xOff;
	public float yOff;
	public float zOff;

//	[SerializeField]
//	private Mover object1;


	//[SerializeField]
	//private Stat energy;


	void Awake () {
		//	energy.Initialize ();
		press = false;
		fCount = spawnWait;
	}
		
	void Update () {

		if (Input.GetKeyDown (userKey)) {
			press = true;
		} 

		if (Input.GetKeyUp (userKey)) {
			press = false;
		}
	}

	void FixedUpdate () {

		fCount -= Time.deltaTime;

		if (press == true && fCount <= 0) {
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x) + xOff, 
				Random.Range (-spawnValues.y, spawnValues.y) + yOff, Random.Range (-spawnValues.z, spawnValues.z) + zOff);
			for (int i = 0; i < waveLength; i++) {


				Quaternion spawnRotation = Quaternion.Euler(0.0f, spawnRotationY, 0.0f);

				Instantiate (hazard1, spawnPosition, spawnRotation);
				spawnRotationY += 360/waveLength;



			}
			fCount = spawnWait;
		}
	}
}
