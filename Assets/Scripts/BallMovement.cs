using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField] float ballBounceSpeed = 18f; // Ball's movement speed
	[SerializeField] float ballPaddleSpeed = 21f;

	Vector3 lastVelocity;
	[Header("Start")]
	Vector3 startForce;
	[SerializeField] float startSpeed = 3f;
	Rigidbody myRigidbody; // Reference to the Rigidbody component

	float paddleYPosition = 0f;
	float ballYPosition = 0f;

	void Start()
	{
		myRigidbody = GetComponent<Rigidbody>();
		startForce = new Vector3(startSpeed, startSpeed, 0);
		// initialize the ball to move to the right
		myRigidbody.AddForce(startForce, ForceMode.Impulse);
	}
	void FixedUpdate()
	{
		lastVelocity = myRigidbody.velocity;
	}
	void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
		{
			ballYPosition = transform.position.y;
			paddleYPosition = collision.transform.position.y;
			float ballToPaddle = (paddleYPosition - ballYPosition) / 3f;
			float paddleXSlower = 1 - Mathf.Abs(ballToPaddle);
			myRigidbody.velocity = new Vector3(
			-Mathf.Sign(lastVelocity.x) * ballPaddleSpeed * paddleXSlower,
			ballPaddleSpeed * -ballToPaddle,
			lastVelocity.z);
		}
		else
		{
			// Reflect the ball's direction based on the collision point with the paddle
			Vector3 reflectDir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
			myRigidbody.velocity = reflectDir * ballBounceSpeed;
		}

	}
	public void Goal(string wall)
	{
		ResetBall();
		if (wall == "Player1Wall")
		{
			startForce = new Vector3(-startSpeed, startSpeed, 0);
			myRigidbody.AddForce(startForce, ForceMode.Impulse);
		}
		else if (wall == "Player2Wall")
		{
			startForce = new Vector3(startSpeed, startSpeed, 0);
			myRigidbody.AddForce(startForce, ForceMode.Impulse);
		}

	}
	void ResetBall()
	{
		transform.position = Vector3.zero;
		myRigidbody.velocity = Vector3.zero;
	}
}
