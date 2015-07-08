using UnityEngine;
using System.Collections;

/**
 * The missile player class handles the player specific missile behaviour
 */
public class MissilePlayer : Missile
{
	/**
	 * Handles the missiles movement
	 */
	private void Update ()
	{
		if (this.IsActive())
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, Config.screenCenter, Time.deltaTime * this.speed);

			if (this.transform.position == Config.screenCenter)
			{
				this.Deactivate();
			}
		}
	}
}
