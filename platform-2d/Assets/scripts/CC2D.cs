using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CC2D : MonoBehaviour 
{

	public CharState charState = new CharState();

	public Rigidbody2D rb2d;
	public Collider2D col2d;


	private void initComponents()
	{
		this.rb2d = this.GetComponent<Rigidbody2D>();
		this.col2d = this.GetComponent<Collider2D>();
	}



	//-- Vertical Movement --//
	public float jumpHeight = 3f;
	public float doubleJumpHeight = 2f;
	public void jump()
	{
		if(this.charState.isGrounded) // Normal Jump
		{
			Vector2 jumpVelocity = new Vector2(this.rb2d.velocity.x, Mathf.Sqrt(-2f* Physics2D.gravity.y*jumpHeight));
			this.rb2d.velocity = jumpVelocity;
			this.charState.isJumping = true;
		}
		else if(this.charState.isJumping) // Double Jump
		{
			Vector2 jumpVelocity = new Vector2(this.rb2d.velocity.x, Mathf.Sqrt(-2f* Physics2D.gravity.y*jumpHeight));
			this.rb2d.velocity = jumpVelocity;
			this.charState.isJumping = false;
		}
	}
	public void cancelJump()
	{
		if(this.rb2d.velocity.y > 0)
		{
			this.rb2d.velocity = new Vector2(this.rb2d.velocity.x, 0f);
		}
	}
	

	//-- Horizontical Movement --//

	public float moveSpeed = 10f;
	public void move(HDirection dir)
	{
		float dirMod;
		switch(dir)
		{
			case HDirection.RIGHT:
				dirMod = 1;
				break;
			case HDirection.LEFT:
				dirMod = -1;
				break;
			default:
				dirMod = 0;
				break;
		}
		this.charState.lastFacing = this.charState.facing;
		this.charState.facing = dir;
		this.rb2d.velocity = new Vector2(moveSpeed*dirMod, this.rb2d.velocity.y);
	}
	public void stop()
	{
		this.rb2d.velocity = new Vector2(0f, this.rb2d.velocity.y);
	}

	private void faceDirection()
	{
		if(this.charState.facing != this.charState.lastFacing)
		{
			this.transform.localScale = new Vector3(
				-1*this.transform.localScale.x, 
				this.transform.localScale.y,
				this.transform.localScale.z);
		}
	}

	//-- Check Grounded --//
	LayerMask groundLayerMask; // initialized in Start
	private void checkGrounded()
	{
		if(this.col2d.IsTouchingLayers(groundLayerMask))
		{
			this.charState.isGrounded = true;
		}
		else
		{
			this.charState.isGrounded = false;
		}
	}



	//-- Start and update with controller's private functions --//

	void Start () 
	{
		initComponents();
		this.groundLayerMask = LayerMask.GetMask(new[] {"ground", "Ground", "GROUND"});
	}
	void Update()
	{
		faceDirection();
		checkGrounded();
	}
	
}
