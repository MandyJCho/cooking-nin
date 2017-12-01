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
	[HideInInspector] public bool gameOn;
	private AudioSource audioSource;
	public AudioClip pickupSound;
	public AudioClip collSound;

	//called before Update and after Awake
	void Start ()
	{
		//initialize references to the player Collider, Rigidbody, and audio source
		playerColl = GetComponent<CapsuleCollider>();
		distFromGround = playerColl.bounds.extents.y;
		playerRigBd = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource> ();
		
		//mouse setting: locked to center of the window. No longer visible on screen
		Cursor.lockState = CursorLockMode.Locked;

		gameOn = true;
		speed = 3.0f;		// default 4.75f
		jumpVel = 7.0f;
		//in the unity editor, freeze rotation on x and z axes on the rigidbody on the player object
	}

	//returns true if the player is not in the air and false otherwise
	bool isGrounded ()
	{
		return Physics.Raycast(transform.position, -Vector3.up, distFromGround + 0.1f);
	}
	
	//plays the pickup sound
	public void playPickupSound()
	{
		audioSource.clip = pickupSound;
		audioSource.Play ();
	}
	
	//plays the collision sound
	public void playCollSound()
	{
		audioSource.clip = collSound;
		audioSource.Play ();
	}
	
	//called once per frame
	void Update ()
	{
		if (gameOn) {
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

			//get the mouse back by hitting enter key
			if (Input.GetKeyDown (KeyCode.Return)) {
				Cursor.lockState = CursorLockMode.None;
			}

			//jump when spacebar is pressed. Can only jump when on the ground, no double-jumping
			if (isGrounded()) {
				playerRigBd.velocity = jump;
			}
		}
		else {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
