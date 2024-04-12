using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Physicsobject
{
    // Start is called before the first frame update
    [SerializeField] float maxRunSpeed = 1;
	[SerializeField] float maxJumpSpeed = 1;
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxRunSpeed, Input.GetAxis("Vertical") * maxJumpSpeed);
		targetVelocity = new Vector2(Input.GetAxis("Horizontal") * maxRunSpeed, 0);
        if (Input.GetButtonDown("Jump") && grounded){
            velocity.y = maxJumpSpeed;

		}


	}
	//2.25 x
    //1.05 y
}
