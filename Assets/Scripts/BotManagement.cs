using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotManagement : MonoBehaviour
{
	GameObject ball;
	[SerializeField] float botSpeed = 5.0f;
	public float lerpSpeed = 5f;
	// Start is called before the first frame update
	void Start()
	{
		ball = FindObjectOfType<BallMovement>().gameObject;
	}

	// Update is called once per frame
	void Update()
	{
		//Move();
		SmoothMove();
	}

	private void Move()
	{
		if (transform.position.y > ball.transform.position.y)
		{
			Vector3 movement = new Vector3(0, -1, 0) * Time.deltaTime * botSpeed;
			transform.Translate(movement);
		}
		else if (transform.position.y < ball.transform.position.y)
		{
			Vector3 movement = new Vector3(0, 1, 0) * Time.deltaTime * botSpeed;
			transform.Translate(movement);
		}
	}
	void SmoothMove()
	{
		// Calculate target position based on ball's Y position
		float targetY = ball.transform.position.y;

		// Use Mathf.Lerp for smooth movement
		transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetY, lerpSpeed * Time.deltaTime), transform.position.z);
	}
}
