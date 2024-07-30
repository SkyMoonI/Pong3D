using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{

	[SerializeField] float playerSpeed = 5.0f;


	// Update is called once per frame
	void Update()
	{
		Move();
	}

	void Move()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Vector3 movement = new Vector3(0, 1, 0) * Time.deltaTime * playerSpeed;
			transform.Translate(movement);

		}
		else if (Input.GetKey(KeyCode.S))
		{
			Vector3 movement = new Vector3(0, -1, 0) * Time.deltaTime * playerSpeed;
			transform.Translate(movement);
		}


	}

}
