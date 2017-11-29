using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	public int score { get; set; }
	private Text displayScore;

	// Use this for initialization
	void Start ()
	{
		displayScore = GameObject.Find("Score").GetComponent<Text>();
		score = 0;
		UpdateDisplayScore();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (score < 0)
			score = 0;

		UpdateDisplayScore();
	}

	void UpdateDisplayScore()
	{
		displayScore.text = "Score: " + score;
		
	}
}
