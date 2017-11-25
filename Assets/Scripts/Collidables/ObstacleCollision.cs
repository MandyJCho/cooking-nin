using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collidables;
using UnityEngine.SocialPlatforms.Impl;

public class ObstacleCollision : MonoBehaviour, Collidable {
	public int pointImpact { get; private set; }
	private ScoreController scoreController;
	
	// Use this for initialization
	void Start ()
	{
		pointImpact = -1;
		scoreController = GameObject.Find("UI/Score").GetComponent<ScoreController>();
	}


	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			scoreController.score += pointImpact;
			
		}
	}

}
