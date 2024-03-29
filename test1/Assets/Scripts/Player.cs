using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// SerializeField 序列号变量 可在布局中进行条件
	// 速度倍数
	[SerializeField] private float speedmultiplier = 1.2345f;
	// 血条
	[SerializeField] private float hpl = 100f;
	// 血量
	private float hp = 100f;
	// 死亡状态
	private bool dead = false; 
	// 无敌状态
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
		// 实现不了,可能需要特殊手段了
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

		// 超过横边界 10.3
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

		// 超过纵边界 4.5
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
		// 鞭尸 不可取
		if (dead)
		{
			// to do 抛出错误
			return;
		}
		// 传来小于0 的值, 有错误
		if (dam <= 0)
			// to do 抛出错误
			return;

		// 无敌不扣血
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
