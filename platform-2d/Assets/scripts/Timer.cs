using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
	private float duration;
	private float counter;

	public Timer (float duration)
	{
		this.duration = duration;
		this.counter = 0;
	}

	public bool tick()
	{
		if (this.counter > this.duration)
		{
			counter = 0f;
			return false;
		}
		else 
		{
			this.counter += Time.deltaTime;
			return true;
		}
	}
	public void reset ()
	{
		this.counter = 0;
	}

}
