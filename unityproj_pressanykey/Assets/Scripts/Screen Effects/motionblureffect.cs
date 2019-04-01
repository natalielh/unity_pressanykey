using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionblureffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.MotionBlur motionBlur;

	public float inSpeed = 2.0f;
	public float outSpeed = 0.4f;
	private float t;


	void Awake () {

		motionBlur = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.MotionBlur>();

		press = false;
		t = 0.0f;
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

		// apply the motion blur effect
		if (t > 0.0f) {
			motionBlur.blurAmount = Mathf.Lerp (0.0f, 0.8f, t);
		}
		else {
			t = 0.0f;
		}

	}
}
