using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColour : MonoBehaviour {

	public float hueMax;
	public float hueMin;
	public float satMax;
	public float satMin;
	public float valMax;
	public float valMin;

	public bool colorAwake = false;
	public bool colorUpdate = false;

	public float colorTime;
	private float fCount;

	public Color lerpedColor = Color.white;

	// Use this for initialization
	void Awake () {
		fCount = colorTime;
			if (colorAwake && gameObject.GetComponent<Renderer> () != null)
				GetComponent<Renderer> ().material.color = 
			Random.ColorHSV (hueMax, hueMin, satMax, satMin, valMax, valMin);
	}
	
	// Update is called once per frame
	void Update () {
		fCount -= Time.deltaTime;
		if (colorUpdate && fCount <= 0 && gameObject.GetComponent<Renderer> () != null) { 
			GetComponent<Renderer> ().material.color = 
				Random.ColorHSV (hueMax, hueMin, satMax, satMin, valMax, valMin);
			fCount = colorTime;
		}


	}
}
