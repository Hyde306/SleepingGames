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

		// �}�E�X�̓����Ɣ��Ε����ɔ��˂����
		if (Input.GetMouseButtonDown(0))
		{
			this.startPos = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			Vector2 endPos = Input.mousePosition;
			Vector2 startDirection = -1 * (endPos - startPos).normalized;
			this.rigid2d.AddForce(startDirection * 500);
		}

		// �e�X�g�p�F�X�y�[�X�L�[�����Œ�~
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.rigid2d.velocity *= 0;
		}


		// Space�L�[�𗣂��Ɠ����o��
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