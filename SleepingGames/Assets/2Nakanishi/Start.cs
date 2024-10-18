using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CharacterController : MonoBehaviour
{

	Rigidbody2D rigid2d;
	private float speed;


	void Start()
	{
		this.rigid2d = GetComponent<Rigidbody2D>();

	}

	void Update()
	{

		if (Input.GetKeyUp(KeyCode.Space))
		{

			this.speed = 100.0f;
			this.rigid2d.AddForce(transform.up * speed);

		}

	}
}