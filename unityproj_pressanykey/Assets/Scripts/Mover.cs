using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float fSpeed;
	public float sSpeed;

	float scaleX;
	float scaleY;
	float scaleZ;

	[SerializeField]
	public float timeOut = 100;

	[SerializeField]
	public float spawnTime = .25f;
	public float scaleTransformX;
	public float scaleTransformY;
	public float scaleTransformZ;

	[System.NonSerialized]
	public float counter;

	[System.NonSerialized]
	public float fCount;


	public void Awake () {
		counter = timeOut;
		fCount = spawnTime;
		//checks to see if there is a rigidbody on the actual object. Helps to prevent buggy slowdown
		if (gameObject.GetComponent<Rigidbody> () != null) {
			GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * fSpeed); //sets object speed
			GetComponent<Rigidbody> ().AddTorque (gameObject.transform.forward * Random.Range (0, 100)); //sets object spin. doesnt work well

		} else {
			Debug.Log ("No Rigidbody Attached");
			return;
		}
	}

	public void Update () {
		counter -= Time.deltaTime; //counter for timeout
		fCount -= Time.deltaTime;

		scaleX = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;

		//if the object reaches timeout time, or the scale is about to go Negative
		if (counter <= 0 || scaleX <=0.01 || scaleY <=0.01 || scaleZ <=0.01) {
			Destroy (gameObject);
		}
		//a scaler
		transform.localScale += new Vector3 (
			scaleTransformX, scaleTransformY, scaleTransformZ
		);

	}

}
