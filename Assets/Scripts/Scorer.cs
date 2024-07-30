using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ScoreEventHandler();
public class Scorer : MonoBehaviour
{
	[SerializeField] Score player1;
	[SerializeField] Score player2;
	public event ScoreEventHandler OnScore;
	BallMovement ballMovement;


	// Start is called before the first frame update
	void Start()
	{
		ballMovement = FindObjectOfType<BallMovement>();
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player1Wall")
		{
			player1.AddScore();
			OnScore?.Invoke();
			ballMovement.Goal("Player1Wall");
		}
		else if (other.gameObject.tag == "Player2Wall")
		{
			player2.AddScore();
			OnScore?.Invoke();
			ballMovement.Goal("Player2Wall");
		}
	}


}
