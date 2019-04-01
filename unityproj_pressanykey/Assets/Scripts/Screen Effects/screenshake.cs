using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenshake : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private Camera mainCamera;

	public float shakeAmount = 1.5f;

	public float inSpeed = 3.0f;
	public float outSpeed = 1.5f;
	private float t;

	void Awake () {

		mainCamera = Camera.main;

		press = false;
		t = 0;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(userKey)) {
			press = true;
		}

		if (Input.GetKeyUp(userKey)) {
			press = false;
		}


		if (press == true) {

			if (t < 1.0f) {
				t += Time.deltaTime * inSpeed;
			}
		}

		if (press == false) {

			if (t > 0.0f) {
				t -= Time.deltaTime * outSpeed;
			}
		}

		// apply the screenshake effect
		if (t > 0) {
			mainCamera.transform.localPosition = Random.insideUnitSphere * shakeAmount * t;
		}
		else{
			t = 0.0f;
			//mainCamera.transform.localPosition = Vector3.zero;
		}


	}
}