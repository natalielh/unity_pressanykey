using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screeneffects : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.BloomOptimized bloom;
	private UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration aberration;

	// Use this for initialization
	void Awake () {

		bloom = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>();
		aberration = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();

		press = false;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKeyDown(userKey)) {
			press = true;

		}

		if (Input.GetKeyUp(userKey)) {
			press = false;
		}





		if (press == true) {

			if (bloom.intensity <= 2.4f) {
				bloom.intensity += 0.01f;
			}

			if (aberration.chromaticAberration <= 100.0f) {
				aberration.chromaticAberration += 2.0f;
			}


		}

		if (press == false) {

			if (bloom.intensity > 0.0f) {
				bloom.intensity -= 0.01f;
			}

			if (aberration.chromaticAberration > 0.0f) {
				aberration.chromaticAberration -= 2.0f;
			}

		}




	}
}