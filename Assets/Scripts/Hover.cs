using System.Collections;
using UnityEngine;

public class Hover : MonoBehaviour
{
	private float minHeight;
	private float maxHeight;
	private float changeHeight;
	
	//called exactly one time when the game starts
	void Start ()
	{
		minHeight = 0.4f;
		maxHeight = 0.4f;
		changeHeight = 0.1f;
	}
	
	void Update ()
	{
		/* if (transform.position.y > maxHeight) {
			changeHeight *= -1.0f;
		}
		
		if (transform.position.y < minHeight) {
			changeHeight *= -1.0f;
		} */
		
		transform.Translate(new Vector3(0, changeHeight, 0) * Time.deltaTime);
	}
}
