using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoshida : MonoBehaviour
{

	Rigidbody2D rigid2d;
	Vector2 startPos;
	private float speed;


	void Start()
	{
		this.rigid2d = GetComponent<Rigidbody2D>();
		this.speed = 100;

	}

	void Update()
	{

		// マウスの動きと反対方向に発射される
		if (Input.GetMouseButtonDown(0))
		{
			this.startPos = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Vector2 endPos = Input.mousePosition;
			Vector2 startDirection = -1 * (endPos - startPos).normalized;
			this.rigid2d.AddForce(startDirection * 550);
		}

		// Spaceキーを離すと動き出す
		//if(Input.GetKeyUp(KeyCode.Space)) {
		//
		//	this.speed = 100.0f;
		//	this.rigid2d.AddForce(transform.up * speed);
		//}

	}

	void FixedUpdate()
	{

		this.rigid2d.velocity *= 0.995f;

	}

}