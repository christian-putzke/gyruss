using UnityEngine;
using System.Collections;

/**
 * The missile enemy class handles the enemy specific missile behaviour
 */
public class MissileEnemy : Missile
{
	/**
	 * The missiles target
	 */
	private Vector3 target;
	
	
	
	/**
	 * Sets the missiles target
	 */
	public void SetTarget(Vector3 target)
	{
		// Increase the distance to the target by 100 so it will go through the origin targets position
		// and further until the lifetime is reached
		this.target = target * 100;
	}


	/**
	 * Handles the missiles movement
	 */
	private void Update ()
	{
		if (this.IsActive())
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.target, Time.deltaTime * this.speed);
		}
	}
}
