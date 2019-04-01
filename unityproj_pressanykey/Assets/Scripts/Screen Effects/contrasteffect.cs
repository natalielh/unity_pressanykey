using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contrasteffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.ColorCorrectionCurves colorcurves;



	void Awake () {

		colorcurves = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();

		press = false;
	}




	void Update () {

		if (Input.GetKeyDown(userKey)) {
			press = true;

		}

		if (Input.GetKeyUp(userKey)) {
			press = false;
		}




		if (press == true) {

			Camera.main.clearFlags = CameraClearFlags.Nothing;

		}

		if (press == false) {

			Camera.main.clearFlags = CameraClearFlags.SolidColor;

		}




	}
}