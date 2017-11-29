using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Collidables;
using NUnit.Framework.Constraints;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

// [Serializable]
public class ObstacleCollision : MonoBehaviour, Collidable {
	public int pointImpact { get; private set; }
	public ScoreController scoreController { get; set; }
	public Image damageImage;
	private PlayerControls player;

	// Use this for initialization
	void Start ()
	{
		damageImage = GameObject.Find("UI/DamageImage").GetComponent<Image>();
		pointImpact = -1;
		scoreController = GameObject.Find("UI/Score").GetComponent<ScoreController>();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControls>();
	}

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player")
		{
			scoreController.score += pointImpact;
			StartCoroutine(Reaction());
		}
	}

	public IEnumerator Reaction()
	{
		//play collision sound
		player.playCollSound();
		Color red = new Color(1, 0, 0, .3f);
		damageImage.color = red;
		yield return new WaitForSeconds(.3f);
		damageImage.color = Color.clear;
	}

}
