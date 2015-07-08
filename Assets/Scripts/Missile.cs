using UnityEngine;
using System.Collections;

/**
 * The missile class handles basic functionality of a missile
 */
public class Missile : MonoBehaviour, IObjectPoolEntity
{
	/**
	 * The missiles speed
	 */
	public float speed = 1f;



	/**
	 * Activates the missile
	 */
	public void Activate(Vector3 spawnPosition)
	{
		this.transform.position = spawnPosition;
		this.gameObject.SetActive(true);
	}


	/**
	 * Deactivates the missile
	 */
	public void Deactivate()
	{
		this.gameObject.SetActive(false);
	}

	
	/**
	 * Returns true if the missile is active
	 */
	public bool IsActive()
	{
		return this.gameObject.activeSelf;
	}
}
