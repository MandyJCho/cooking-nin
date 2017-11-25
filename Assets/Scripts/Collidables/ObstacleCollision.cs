using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collidables;

public class ObstacleCollision : MonoBehaviour, Collidable {
	public int pointImpact { get; private set; }
	private static int collsionScore { get; set; }

	static ObstacleCollision()
	{
		collsionScore = 0;
	}
	
	// Use this for initialization
	void Start ()
	{
		pointImpact = -1;
	}


	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			collsionScore += pointImpact;
			Debug.Log(collsionScore);
		}
	}

}
