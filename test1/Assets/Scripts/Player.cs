using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	// 序列号变量 可在布局中进行条件
	[SerializeField] private float speedmultiplier = 1.2345f;
	private bool dead = false;

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("start test1 begin");
		Reset();
	}


	// Update is called once per frame
	void Update()
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
		}

		//if Math.Abs() .abs()
	}

	private void Reset()
	{
		dead = false;
	}
}
