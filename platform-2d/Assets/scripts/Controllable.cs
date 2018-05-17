using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
	public class Controllable : MonoBehaviour {


	Rigidbody2D rb2d;
	CapsuleCollider2D cc2d;

	// Use this for initialization
	void Start () 
	{
		this.rb2d = this.GetComponent<Rigidbody2D> ();
		this.cc2d = this.GetComponent<CapsuleCollider2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 )
		{
			if (Mathf.Sign(Input.GetAxis("Horizontal")) == Mathf.Sign(this.direction))
			{
				this.moveForward (this.maxSpeed);
			}else{
				this.flip ();
				this.moveForward(this.maxSpeed);
			}
		}
		if(Input.GetAxis("Jump") > 0)
		{
			jump();
		}


	}


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
	private float jumpHeight = 3f;
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
	void moveForward (float moveSpeed)
	{
		this.rb2d.AddForce (
			new Vector2(moveSpeed-this.speed, 0)
			*this.accelerationMultiplier
			*this.direction);
		Debug.Log ("Moving Forward");
	}
	void flip ()
	{
		this.transform.localScale = (new Vector3(this.transform.localScale.x*-1f,this.transform.localScale.y,this.transform.localScale.z));
	}
	void jump ()
	{
		/*this.rb2d.AddForce(
			new Vector2(
				0,jumpHeight
			)
		);*/
		Vector2 jumpVelocity = new Vector2(this.rb2d.velocity.x, Mathf.Sqrt(-2f* Physics2D.gravity.y*jumpHeight));
		this.rb2d.velocity = jumpVelocity;
	}




}
}

