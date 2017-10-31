using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
	//player speed
	private float speed;
	private float jumpVel;
	private float distFromGround;
	private CapsuleCollider playerColl;
	private Rigidbody playerRigBd;
	public Text score;
	private int counter;

	//called before Update and after Awake
	void Start ()
	{
		//initialize references to the player Collider and Rigidbody
		playerColl = GetComponent<CapsuleCollider>();
		distFromGround = playerColl.bounds.extents.y;
		playerRigBd = GetComponent<Rigidbody>();
		
		//mouse setting: locked to center of the window. No longer visible on screen
		Cursor.lockState = CursorLockMode.Locked;

		speed = 7.0f;
		jumpVel = 5.0f;
		counter = 0;
		DisplayScore ();
		//in the unity editor, freeze rotation on x and z axes on the rigidbody on the player object
	}

	//returns true if the player is not in the air and false otherwise
	bool isGrounded ()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distFromGround + 0.1f);
	}
	
	//called once per frame
	void Update ()
	{
		//vertical and horizontal values controlled internally by unity
		float translation = Input.GetAxis ("Vertical") * speed;		//along z axis, forwards and backwards
		float strafe = Input.GetAxis ("Horizontal") * speed;		//along x axis, left and right
		//how high to jump
		float moveJump = Input.GetAxis ("Jump");
		Vector3 jump = Vector3.up * jumpVel * moveJump;

		//keeps movements smooth and in time w/ updates
		translation *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate (strafe, 0, translation);

		//get the mouse back by hitting escape key
		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}

		//no sprinting bc that doesn't make sense. Instead, add boost pickup

		//jump when spacebar is pressed. Can only jump when on the ground, no double-jumping
		if (isGrounded()) {
			playerRigBd.velocity = jump;
		}
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
