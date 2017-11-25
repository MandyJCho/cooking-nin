using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Collidables;
using NUnit.Framework.Constraints;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

// [Serializable]
public class ObstacleCollision : MonoBehaviour, Collidable {
	public int pointImpact { get; private set; }
	private ScoreController scoreController;
	public Image damageImage;

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
			StartCoroutine(FlashOnDamage());
		}
	}

	IEnumerator FlashOnDamage()
	{
		Color red = new Color(1, 0, 0, .3f);
		damageImage.color = red;
		yield return new WaitForSeconds(.3f);
		damageImage.color = Color.clear;
	}

}
