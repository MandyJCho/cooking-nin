using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
	private PlayerControls player;
	private string Score { get; set; }

	// Use this for initialization
	void Start ()
	{
		// userful for when we're keeping track of score
		player = GameObject.FindWithTag("Player").GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
