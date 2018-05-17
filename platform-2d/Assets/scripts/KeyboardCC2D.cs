using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCC2D : MonoBehaviour 
{

	CC2D cc2d;
	private KeyBTN upKey = new KeyBTN(new[] {KeyCode.W, KeyCode.UpArrow});
	private KeyBTN downKey = new KeyBTN(new[] {KeyCode.S, KeyCode.DownArrow});
	private KeyBTN leftKey = new KeyBTN(new[] {KeyCode.A, KeyCode.LeftArrow});
	private KeyBTN rightKey = new KeyBTN(new[] {KeyCode.D, KeyCode.RightArrow});
	private KeyBTN jumpKey = new KeyBTN(KeyCode.Space);

	// Use this for initialization
	void Start () 
	{
		this.cc2d = this.GetComponent<CC2D>();
	}
	
	// LateUpdate is called once per frame
	void Update () 
	{
		

		if(leftKey.isPressed())
		{
			cc2d.move(HDirection.LEFT);
		}
		if(rightKey.isPressed())
		{
			cc2d.move(HDirection.RIGHT);
		}
		if(jumpKey.isBeingPressed())
		{
			cc2d.jump();
		}
		if(leftKey.isBeingPressed())
		{
			cc2d.move(HDirection.LEFT);
		}
		if(rightKey.isBeingPressed())
		{
			cc2d.move(HDirection.RIGHT);
		}
		if(leftKey.isBeingUnpressed() || rightKey.isBeingUnpressed())
		{
			cc2d.stop();
		}
	}
}
