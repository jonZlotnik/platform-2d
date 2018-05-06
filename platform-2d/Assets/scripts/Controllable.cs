using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Controllable
{
	float maxSpeed { get; }
	float speed { get; }
	float jumpHeight { get; }
	int direction { get; }
	Vector2 position { get; }

	bool isRunning { get; }
	bool isJumping { get; }
	bool isGrounded { get; }
	bool isIdle { get; }

	void updateDirection ();
	void updatePosition ();

	void moveForward ();
	void flip ();
	void jump ();
	void run ();
	void walk ();



}
