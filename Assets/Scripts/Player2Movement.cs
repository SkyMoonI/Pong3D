using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{

	[SerializeField] float playerSpeed = 5.0f;

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	void Move()
	{
		if (transform.position.y < 5f && transform.position.y > -3f)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				Vector3 movement = new Vector3(0, 1, 0) * Time.deltaTime * playerSpeed;
				transform.Translate(movement);
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				Vector3 movement = new Vector3(0, -1, 0) * Time.deltaTime * playerSpeed;
				transform.Translate(movement);
			}

		}
	}
}
