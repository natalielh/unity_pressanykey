using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicPlay : MonoBehaviour {

	private int waveLength = 1;

	public KeyCode userKey;
	public AudioClip otherClip;

	private bool press;


	void Awake () {
		press = false;
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


		if (press == true) {
			for (int i = 0; i < waveLength; i++) {


				AudioSource audio = GetComponent<AudioSource>();
				audio.clip = otherClip;
				audio.Play();

			}
		}
	}
}
