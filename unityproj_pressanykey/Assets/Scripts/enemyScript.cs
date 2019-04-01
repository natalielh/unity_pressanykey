using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour {

	public float speed;
	GameObject main;
	Transform player;
	public int fCount = 200;

	void Start () {
		main = GameObject.Find ("RadialSphereSpawner");
		player = main.transform;
		speed = speed + Random.Range(0,7);

		GetComponent<Rigidbody> ().AddTorque (gameObject.transform.right * Random.Range (0, 100));
	}

	void FixedUpdate () {
		
		float z = Mathf.Atan2 ((player.transform.position.x - transform.position.x),
			         (player.transform.position.z - transform.position.z))
		         * Mathf.Rad2Deg - 90;

		transform.eulerAngles = new Vector3 (0, z, 0);
		GetComponent<Rigidbody> ().AddForce (gameObject.transform.forward * speed);
		GetComponent<Rigidbody> ().AddForce (gameObject.transform.right * speed);
			

	}
}
