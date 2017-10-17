using System.Collections;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
	Vector2 mouseLook;					//keeps track of how much movement the camera has made
	Vector2 smoothV;					//smooths mouse movement
	public float sensitivity = 5.0f;	//mouse sensitivity
	public float smoothing = 2.0f;		//how much mouse smoothing you want
	private GameObject player;			//points to player object

	//called before Update and after Awake
	void Start ()
	{
		//sets player object to point to the parent that the code is attached to. Code is attached to camera, which is a child of the player object
		player = this.transform.parent.gameObject;
	}

	//called once per frame
	void Update ()
	{
		//mouse delta
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		//multiply by mouse sensitivity and smoothing
		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		//linear interpolation of movement, causes smooth moving between 2 points
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		//holds sum of camera movement to then apply it to the player character
		mouseLook += smoothV;

		//Restrict looking up and down
		mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

		//rotates around camera's up and down
		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		//rotates around player's up and down
		player.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, player.transform.up);
	}
}
