using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// SerializeField ���кű��� ���ڲ����н�������
	// �ٶȱ���
	[SerializeField] private float speedmultiplier = 1.2345f;
	// Ѫ��
	[SerializeField] private float hpl = 100f;
	// Ѫ��
	private float hp = 100f;
	// ����״̬
	private bool dead = false; 
	// �޵�״̬
	private bool invincible = false;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("start test1 begin");
		Reset();
	}


	// Update is called once per frame
	void Update()
	{
		if (!dead)
		{
			MoveStart()
		}
		if (dead)
			Debug.Log("dead: " + hp);
		//if Math.Abs() .abs()
	}

	private void Reset()
	{
		// ʵ�ֲ���,������Ҫ�����ֶ���
		/*
		dead = false;
		hp = hpl;
		Debug.Log("Reset: " + hp);
		*/
	}

	private void MoveStart()
	{
		float x = Input.GetAxis("Horizontal") * speedmultiplier * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * speedmultiplier * Time.deltaTime;
		float z = transform.position.z;
		transform.position += new Vector3(x, y, z);
		//transform.position = new Vector3(transform.position.x + 1,0, 0);

		// ������߽� 10.3
		if (Math.Abs(transform.position.x) > 10.3f)
		{
			float reset_x = 10.3f;
			if (transform.position.x < 0)
			{
				reset_x = -10.3f;
			}
			transform.position = new Vector3(reset_x, transform.position.y, transform.position.z);
			Damage(1);
		}

		// �����ݱ߽� 4.5
		if (Math.Abs(transform.position.y) > 4.5f)
		{
			float reset_y = 4.5f;
			if (transform.position.y < 0)
			{
				reset_y = -4.5f;
			}
			transform.position = new Vector3(transform.position.x, reset_y, transform.position.z);
			Damage(1);
		}
	}

	private void Damage(float dam)
	{
		// ��ʬ ����ȡ
		if (dead)
		{
			// to do �׳�����
			return;
		}
		// ����С��0 ��ֵ, �д���
		if (dam <= 0)
			// to do �׳�����
			return;

		// �޵в���Ѫ
		if (invincible)
			return;

		hp = hp - dam;
		if (hp < 0)
		{
			hp = 0;
			dead = true;
		}
		Debug.Log("Damage: " + hp);
	}
}
