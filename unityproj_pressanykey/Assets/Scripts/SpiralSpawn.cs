using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SpiralSpawn : MonoBehaviour {

	public GameObject hazard1; 			//spawned object
	public KeyCode userKey;	
	public AudioClip otherClip;


	public Vector3 spawnValues;			//spawner Range, set in Unity IDE
	public int waveLength;				//number of spawned objects, set in Unity IDE

	private float fCount;				//counter to determine "rate of fire." Gets set to spawnWait, then reduces to 0, then resets again
	public float spawnWait;				//fCount spawn rate time

	private float spawnRotationY;		

	public float xOff;					//x offset for spawn location
	public float yOff;					//y offset for spawn location
	public float zOff;					//z offset for spawn location

	private bool press;

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
		//sets bool based on keypress
		if (Input.GetKeyDown (userKey)) {
			press = true;
		} 

		if (Input.GetKeyUp (userKey)) {
			press = false;
		}
	}

	void FixedUpdate () {


		fCount -= Time.deltaTime;

		//only spawn if key is pressed, includes "rate of fire"
		if (press == true && fCount <= 0) {
			//sets a spawn position for the set of objects based on public variables. spawnValues is a range, while the
			//offsets are absolute.
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x) + xOff, 
				Random.Range (-spawnValues.y, spawnValues.y) + yOff, Random.Range (-spawnValues.z, spawnValues.z) + zOff);
			
			for (int i = 0; i < waveLength; i++) {


				Quaternion spawnRotation = Quaternion.Euler(0.0f, spawnRotationY, 0.0f); //sets Y rotation in 3D space

				Instantiate (hazard1, spawnPosition, spawnRotation);  //spawn object based on calculated variables
				spawnRotationY += 360/waveLength;		//calculates angle for next spawned object to create perfect circle spawn

				AudioSource audio = GetComponent<AudioSource>();  //play audio, if set in Unity IDE. This sound is not attached to the object itself
				audio.clip = otherClip;
				audio.Play();

			}
			fCount = spawnWait; //reset "rate of fire" to 0
		}
	}
}
