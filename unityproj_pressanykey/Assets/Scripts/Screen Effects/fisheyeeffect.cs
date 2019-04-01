using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fisheyeeffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.Fisheye fisheye;

	public float inSpeed = 3.0f;
	public float outSpeed = 1.0f;
	private float t;

	public bool expandX = true;
	public bool expandY = true;


	void Awake () {

		fisheye = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Fisheye>();

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
			if (expandY) {
				fisheye.strengthX = Mathf.Lerp (0.0f, 1.5f, t);	
			}
			else {
				fisheye.strengthX = 0.0f;
			}
			if (expandX) {
				fisheye.strengthY = Mathf.Lerp (0.0f, 1.5f, t);
			}
			else{
				fisheye.strengthY = 0.0f;
			}


		}
		else {
			t = 0.0f;
		}


	}
}