using UnityEngine;
using System.Collections;

/**
 * The enemy class handles the enemy ship behaviour
 */
public class Enemy : Ship, IObjectPoolEntity
{
	public void Activate()
	{
		this.gameObject.SetActive(true);
	}

	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}

	public bool IsActive()
	{
		return this.gameObject.activeSelf;
	}

	/**
	 * Destroies the enemies ship
	 */
	protected override void Destroy ()
	{
		Debug.Log ("enemy destroied!");
	}
}
