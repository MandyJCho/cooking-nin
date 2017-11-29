using System.Collections;
using UnityEngine;

public class Hover : MonoBehaviour
{
	private float changeHeight;			//how fast the item moves up and down
	
	//called exactly one time when the game starts
	void Start ()
	{
		changeHeight = 0.5f;
	}
	
	//called once per frame
	void Update ()
	{	
		//if the item is higher than a limit, change its movement to point down
		if (transform.position.y > 1.1f) {
			changeHeight = -0.5f;
		}
		//if the item is lower than a limit, change its movement to point up
		if (transform.position.y < 0.6f) {
			changeHeight = 0.5f;
		}
		//translate the item on its y-axis
		transform.Translate(new Vector3(0, changeHeight, 0) * Time.deltaTime / 1.5f);
	}
}
