using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blureffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.BlurOptimized blur;

	public float inSpeed = 3.0f;
	public float outSpeed = 0.5f;
	private float t;


	void Awake () {

		blur = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>();

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
			blur.blurSize = Mathf.Lerp (0.0f, 9.0f, t);
		}
		else {
			t = 0.0f;
		}


	}
}
