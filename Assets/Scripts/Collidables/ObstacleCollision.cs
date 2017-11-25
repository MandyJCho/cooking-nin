using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collidables;

public class ObstacleCollision : MonoBehaviour, Collidable {
	public int pointImpact { get; private set; }

	// Use this for initialization
	void Start ()
	{
		pointImpact = -2;
	}
	

	public void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			
		}
	}
}
