using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreenActive : MonoBehaviour {

	public GameObject myGameObject;

	public void YesClick () {
		myGameObject.SetActive(true); //myGameObject = GameObject var
	}
}
