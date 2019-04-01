using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noiseeffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.NoiseAndGrain noise;

	public float inSpeed = 3.0f;
	public float outSpeed = 0.5f;
	private float t;


	void Awake () {

		noise = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.NoiseAndGrain>();

		press = false;
		t = 0.0f;
	}


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

		// apply the blurring effect
		if (t > 0.0f) {
			noise.intensityMultiplier = Mathf.Lerp (0.0f, 10.0f, t);
		}
		else {
			t = 0.0f;
		}


	}
}