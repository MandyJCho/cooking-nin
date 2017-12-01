using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Collidables;
//using NUnit.Framework.Constraints;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CollectibleCollision : MonoBehaviour, Collidable {
    public int pointImpact { get; private set; }
    public static int TOTAL = 0;
    public ScoreController scoreController { get; set; }
	private PlayerControls player;

    // Use this for initialization
    void Start ()
    {
        pointImpact = 1;
        scoreController = GameObject.Find("UI/Score").GetComponent<ScoreController>();
        TOTAL++;
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControls>();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreController.score += pointImpact;
			GameObject.Destroy(gameObject);
            StartCoroutine(Reaction());
			TOTAL--;
        }
    }

    public IEnumerator Reaction()
    {
        //play pickup sound
		player.playPickupSound();
        yield return null;
    }
}
