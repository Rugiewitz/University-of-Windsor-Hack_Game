using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	int score = 0;
	public int theScore = 0;
	int health = 5;
	public int theHealth = 5;
	public GUIText scoreText;
	public GUIText healthtText;

	void Update()
	{
		theScore = score;
		theHealth = health;
		scoreText.text = "Score: " + score;
		healthtText.text = "Health: " + health;
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		if(score == 21)
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

	public void SubHealth (int newValue)
	{
		health = health - newValue;
		if(health == 0)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

}