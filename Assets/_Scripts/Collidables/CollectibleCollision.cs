using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Collidables;
using NUnit.Framework.Constraints;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CollectibleCollision : MonoBehaviour, Collidable {
    public int pointImpact { get; private set; }
    public static int TOTAL = 0;
    public ScoreController scoreController { get; set; }

    // Use this for initialization
    void Start ()
    {
        pointImpact = 1;
        scoreController = GameObject.Find("UI/Score").GetComponent<ScoreController>();
        TOTAL++;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreController.score += pointImpact;
            StartCoroutine(Reaction());
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scoreController.score += pointImpact;
            GameObject.Destroy(gameObject);
            TOTAL--;
            // StartCoroutine(Reaction());
        }
    }

    public IEnumerator Reaction()
    {
         // play sounds
        yield return null;
    }
}
