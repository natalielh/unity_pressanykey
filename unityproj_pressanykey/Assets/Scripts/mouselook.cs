using UnityEngine;
using System.Collections;

public class mouselook : MonoBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV; // smoothing vector to smooth the movement
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;
	public float upDownMaxAngle = 10.0f;
	public float leftRightMaxAngle = 10.0f;

	GameObject character;

	// Use this for initialization
	void Start ()
	{
		// without doing this, the camera rotation always kept spazzing out
		// i'm not 100% sure how making the camera as a child of another gameObject
		// and controlling them both with this script made it work, but it works 😳 o_o
		character = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update ()
	{

		// mouseDelta is made up of the x and y of the mouse on the screen
		// it has to be translated to fit the camera looking at the ground, instead of to the side
		var mouseDelta = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		mouseDelta = Vector2.Scale (mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, mouseDelta.x, 1.0f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, mouseDelta.y, 1.0f / smoothing);
		mouseLook += smoothV;

		// clamp looking left and right
		// with guessing and testing, i found that 0.0f works best for the camera never spazzing out
		mouseLook.x = Mathf.Clamp (mouseLook.x, 0.0f - leftRightMaxAngle, 0.0f + leftRightMaxAngle);

		// clamp looking up and down
		// 0 is top, -90 is straight forward, -180 is bottom (in terms of looking straight down)
		mouseLook.y = Mathf.Clamp (mouseLook.y, -90.0f - upDownMaxAngle, -90.0f + upDownMaxAngle);

		// apply the transformations to the camera
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right); // the "-" sign in front of mouselook.y inverts the movement
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, transform.up);
	}
}
