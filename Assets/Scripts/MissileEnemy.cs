using UnityEngine;
using System.Collections;

/**
 * The missile enemy class handles the enemy specific missile behaviour
 */
public class MissileEnemy : Missile
{
	/**
	 * Handles the missiles movement
	 */
	private void Update ()
	{
		if (this.IsActive())
		{
			// TODO: Add enemy specific missile movement
//			this.transform.position = Vector3.MoveTowards(this.transform.position, Config.screenCenter, Time.deltaTime * this.speed);
//
//			if (this.transform.position == Config.screenCenter)
//			{
//				this.Deactivate();
//			}
		}
	}
}
