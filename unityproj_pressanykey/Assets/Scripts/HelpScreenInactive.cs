using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenInactive : MonoBehaviour {

	public GameObject myGameObject;

	public void YesClick () {
		myGameObject.SetActive(false); //myGameObject = GameObject var
	}
}

