using UnityEngine;
using System.Collections;

/**
 * The player class handles the player inputs and the player ship behaviour
 */
public class Player : Ship
{
	/**
	 * The missile object pool component
	 */
	private ObjectPool missileObjectPool;



	/**
	 * Grep and cache needed components
	 */
	private void Start()
	{
		this.missileObjectPool = this.GetComponent<ObjectPool>();
	}


	/**
	 * Handles the player inputs
	 */
	private void Update ()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.RotateAround(this.rotateRightAxis);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.RotateAround(this.rotateLeftAxis);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			var objectPoolEntity = this.missileObjectPool.GetObjectPoolEntity();
			objectPoolEntity.Activate(this.transform.position);
		}
	}


	/**
	 * Destroies the players ship
	 */
	protected override void Destroy ()
	{
		Debug.Log ("player destroied!");
	}
}
