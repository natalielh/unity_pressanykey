using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twirleffect : MonoBehaviour {

	[SerializeField]
	private KeyCode userKey;
	private bool press;

	private UnityStandardAssets.ImageEffects.Twirl twirl;

	public float inSpeed = 4.0f;
	public float outSpeed = 0.8f;
	private float t;

	// Use this for initialization
	void Awake () {

		twirl = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Twirl>();

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





		if (t >= 1.0f) {
			t = 0.0f;
		} 

		if (press == true) {

			//			if (twirl.angle <= 350.0f) {
			//				twirl.angle += 10.0f;
			//			}
			//		}
			if (t < 1.0f) {
				t += Time.deltaTime * inSpeed;
			}
		}


		if (press == false) {

			//			if (twirl.angle > 0.0f) {
			//				twirl.angle -= 10.0f;
			//			}
			//		}
			if (t > 0.0f) {
				t -= Time.deltaTime * outSpeed;
			}
		}

		// apply the twirl changes
		if (t > 0.0f) {
			twirl.angle = (Mathf.Lerp (0.0f, 360.0f, t));
		}
		else {
			t = 0.0f;
		}




	}
}