using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {




	//--------------------------------------------------------
	// MonoBehaviour
	//


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}









	//------------------------------------------------------------
	// Controllable
	//

	private float maxSpeed { get; }
	private float speed { get; }
	private float jumpHeight { get; }
	private int direction { get; set; }
	private Vector2 position { get; set; }

	private bool isRunning { get; }
	private bool isJumping { get; }
	private bool isGrounded { get; }
	private bool isIdle { get; }

	void updateDirection ()
	{
		this.direction = (int)Mathf.Sign(this.transform.localScale.x);
	}
	void updatePosition ()
	{
		this.position.Set (this.position.x, this.position.y);
	}

//	void moveForward ()
//	{
//		
//	}
//	void flip ();
//	void jump ();
//	void run ();
//	void walk ();







}
