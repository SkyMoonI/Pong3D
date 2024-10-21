using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI ScoreText;
	Scorer scorer;
	[SerializeField] Score player1;
	[SerializeField] Score player2;

	void Start()
	{
		scorer = FindObjectOfType<Scorer>();
		scorer.OnScore += ScoreTextChange;

	}

	void ScoreTextChange()
	{
		ScoreText.text = player2.playerScore.ToString() + " - " + player1.playerScore.ToString();
	}

}
