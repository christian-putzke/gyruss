using UnityEngine;
using System.Collections;

/**
 * The enemy class handles the enemy ship behaviour
 */
public class Enemy : Ship, IObjectPoolEntity
{
	/**
	 * Activates the enemy
	 */
	public void Activate(Vector3 spawnPosition)
	{
		this.gameObject.SetActive(true);
	}


	/**
	 * Deactivates the enemy
	 */
	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}


	/**
	 * Returns true if the enemy is active
	 */
	public bool IsActive()
	{
		return this.gameObject.activeSelf;
	}


	/**
	 * Destroies the enemies ship
	 */
	protected override void Destroy()
	{
		this.Deactivate();
		this.life = 1; // TODO: remove hardcoded reset
	}
}
