using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
	//player speed
	public float speed = 5.0f;
	public Text score;
	private int counter;

	//called before Update and after Awake
	void Start ()
	{
		//mouse setting: locked to center of the window. No longer visible on screen
		Cursor.lockState = CursorLockMode.Locked;

		counter = 0;
		DisplayScore ();
		//in the unity editor, freeze rotation on x and z axes on the rigidbody on the player object
	}

	//called once per frame
	void Update ()
	{
		//vertical and horizontal values controlled internally by unity
		float translation = Input.GetAxis ("Vertical") * speed;		//along z axis, forwards and backwards
		float strafe = Input.GetAxis ("Horizontal") * speed;		//along x axis, left and right

		//keeps movements smooth and in time w/ updates
		translation *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate (strafe, 0, translation);

		//get the mouse back by hitting escape key
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		//sprint if left shift is held down
		if (Input.GetKey (KeyCode.LeftShift)) {
			speed = 7.0f;
		}
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			speed = 5.0f;
		}

		//jump when spacebar is pressed

	}

	//handles collisions
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.CompareTag("sushi")) {
			col.gameObject.SetActive (false);
			counter++;
			DisplayScore ();
		}
	}

	void DisplayScore()
	{
		score.text = "Sushi: " + counter.ToString ();
	}
}
