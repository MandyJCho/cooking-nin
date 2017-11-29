using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private int min = 0;
	private int sec = 0;
	public Text displayTimer;
	private float timeLeft;
	private PlayerControls player;
	public Text endGame;
	private string gameoverText;
 
	//called before Update and after Awake
	void Start()
	{
		min = 0;
		sec = 180;
		timeLeft = min * 60f + sec;
		player = GetComponent<PlayerControls>();
		endGame.enabled = false;
	}
 
	//called once per frame
	void Update()
	{
		//if there's still time left
		if (timeLeft > 0.0f && CollectibleCollision.TOTAL > 0) {
			//decrement timer
			timeLeft -= Time.deltaTime;
			min = Mathf.FloorToInt(timeLeft / 60f);
			sec = Mathf.FloorToInt(timeLeft % 60f);
 
			//show current time left
			displayTimer.text = "Time : " + min.ToString() + ":" + sec.ToString("00");
		}
		else
		{
			Debug.Log(CollectibleCollision.TOTAL);
			if (CollectibleCollision.TOTAL == 0)
				endGame.text = "CONGRATULATIONS!\nItadakimasu!";
			else 
				endGame.text = "Time ran out!\nGame Over!";
	        
			displayTimer.text = "Time : 0:00";
			player.gameOn = false;
			endGame.enabled = true;
		}

	    
	}
}
