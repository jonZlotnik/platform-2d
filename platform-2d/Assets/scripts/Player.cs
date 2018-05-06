﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {




	//--------------------------------------------------------
	// MonoBehaviour
	//

	Rigidbody2D rb2d;
	BoxCollider2D bc2d;

	// Use this for initialization
	void Start () 
	{
		this.rb2d = this.GetComponent<Rigidbody2D> ();
		this.bc2d = this.GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 )
		{
			if (Mathf.Sign(Input.GetAxis("Horizontal")) == Mathf.Sign(this.direction))
			{
				this.moveForward ();
			}else{
				this.flip ();
				this.moveForward();
			}
		}


	}









	//------------------------------------------------------------
	// Controllable
	//

	private bool isRunning;
	private bool isJumping;
	private bool isGrounded ;
	private bool isIdle;

	void updateDirection ()
	{
		this.direction = (int)Mathf.Sign(this.transform.localScale.x);
	}
	private float maxSpeed = 10;
	private float speed{
		get {
			return Mathf.Abs (this.rb2d.velocity.x);
		}
	}
	private float velX{
		get{
			return this.rb2d.velocity.x;
		}
	}
	private float velY{
		get {
			return this.rb2d.velocity.y;
		}
	}
	private float accelerationMultiplier = 20;
	private float jumpHeight;
	private float direction {
		get {
			return Mathf.Sign(this.transform.localScale.x);
		}
		set{}
	}
	private Vector2 position{
		get{
			return new Vector2 (this.transform.position.x, this.transform.position.y);
		}
	}

//	void moveForward ()
//	{
//		
//	}
//	void flip ();
//	void jump ();
//	void run ();
//	void walk ();
	void moveForward ()
	{
		this.rb2d.AddForce (
			new Vector2(this.maxSpeed-this.speed, 0)
			*this.accelerationMultiplier
			*this.direction);
		Debug.Log ("Moving Forward");
//		if(this.speed < this.maxSpeed)
//		{
//			this.rb2d.AddForce()
//		}
	}
	void flip ()
	{
		this.transform.localScale = (new Vector3(this.transform.localScale.x*-1f,this.transform.localScale.y,this.transform.localScale.z));
	}
	//void jump ();
	//void run ();
	//void walk ();







}