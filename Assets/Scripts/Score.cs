using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

	public int playerScore;

	public void AddScore()
	{
		playerScore++;
	}

	public void ResetScore()
	{
		playerScore = 0;
	}

}
