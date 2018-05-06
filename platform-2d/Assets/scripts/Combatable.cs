using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Combatable
{

	int health {
		get;
	}
	bool isInvincible {
		get;
	}


	bool takeDamage(Damage damage);

}
